using AutoMapper;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands;
using GondorsLegacy.Services.Reservation.Constants;
using GondorsLegacy.Services.Reservation.Entities;
using GondorsLegacy.Services.Reservation.Models;
using GondorsLegacy.Services.Reservation.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints;

public class CreateReservationRequest
{
    public Guid CustomerId { get; set; } // Müşteri kimliği
    public string CustomerFirstName { get; set; }  // Müşteri adı
    public string CustomerLastName { get; set; }  // Müşteri adı
    public Guid HotelId { get; set; } // Otel kimliği
    public string HotelName { get; set; } // Otel adı
    public DateTime CheckInDate { get; set; }  // Giriş tarihi
    public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
    public RoomType RoomType { get; set; }  // Oda tipi
    public string RoomNumber { get; set; } // Oda numarası
    public decimal TotalPrice { get; set; }  // Toplam fiyat
    public int NumberOfGuests { get; set; }  // Konuk sayısı
    public string CustomerEmail { get; set; } // Müşteri e-posta adresi
    public ReservationStatus ReservationStatus { get; set; } // Rezervasyon durumu
    public string PaymentInformation { get; set; } // Ödeme bilgileri
    public string SpecialRequests { get; set; } // Özel istekler
    public int NumberOfAdults { get; set; } // Yetişkin kişi sayısı
    public int NumberOfChildren { get; set; } // Çocuk kişi sayısı
    public PaymentStatus PaymentStatus { get; set; } // Ödeme durumu

}

public class CreateReservationResponse
{
    public Guid ReservationId { get; set; }
}

public class CreateReservationRequestHandler : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("api/v1/reservation/create", HandleAsync)
            .WithName("CreateReservation")
            .Produces<CreateReservationResponse>(statusCode: StatusCodes.Status201Created, contentType: "application/json")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new Microsoft.OpenApi.Models.OpenApiOperation
            {
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Reservations" } },
                RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "CreateReservationRequest" }
                            }
                        }
                    },
                    Required = true
                }
            });
    }

    private static async Task<IResult> HandleAsync(IMediator dispatcher, [FromBody] CreateReservationRequest request, IMapper mapper)
    {
        try
        {
            var reservation = mapper.Map<Entities.Reservation>(request);

            var validator = new ReservationValidator();

            var result = validator.Validate(reservation);

            if (result.IsValid)
            {
                await dispatcher.Send(new CreateReservationCommand { Reservation = reservation });

                var response = new CreateReservationResponse
                {
                    ReservationId = reservation.Id
                };

                // İşlem başarılı olduğunda 201 Created yanıtı dön
                return Results.Created($"api/v1/reservations/{response.ReservationId}", response);
            }
            else
            {
                // Doğrulama hatası durumunda uygun bir hata yanıtı veriyoruz
                var errorDetails = new ErrorResponseModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = Messages.InvalidReservationRequestMessage,
                    ErrorDetails  = result.Errors.Select(error => error.ErrorMessage).ToList()
                };

                // 400 Bad Request yanıtı dön
                return Results.BadRequest(error:errorDetails);
            }

          
        }
        catch (Exception ex)
        {
            // Diğer hata durumları için uygun bir hata yanıtı verin
            var errorResponse = new ErrorResponseModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = Messages.DefaultErrorMessage,
                ErrorDetails = new List<string> { ex.Message }
            };

            // 500 Internal Server Error yanıtı döndürün
            return Results.BadRequest();

        }
    }

}




