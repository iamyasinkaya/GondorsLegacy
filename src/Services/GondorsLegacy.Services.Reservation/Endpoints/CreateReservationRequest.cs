using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands;
using GondorsLegacy.Services.Reservation.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints;

public class CreateReservationRequest
{
    public Guid CustomerId { get; set; } // Müşteri kimliği
    public string CustomerFirstName { get; set; }  // Müşteri adı
    public string CustomerLastName { get; set; }  // Müşteri adı
    public DateTime CheckInDate { get; set; }  // Giriş tarihi
    public DateTime CheckOutDate { get; set; }  // Çıkış tarihi
    public RoomType RoomType { get; set; }  // Oda tipi
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
        builder.MapPost("api/v1/reservations", HandleAsync)
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

    private static async Task<IResult> HandleAsync(IMediator dispatcher, [FromBody] CreateReservationRequest request)
    {
        var reservation = new Entities.Reservation
        {
            CustomerId = request.CustomerId,
            CustomerFirstName = request.CustomerFirstName,
            CustomerLastName = request.CustomerLastName,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            RoomType = request.RoomType,
            NumberOfGuests = request.NumberOfGuests,
            CustomerEmail = request.CustomerEmail,
            ReservationStatus = request.ReservationStatus,
            SpecialRequests = request.SpecialRequests,
            NumberOfAdults = request.NumberOfAdults,
            NumberOfChildren = request.NumberOfChildren,
            PaymentStatus = request.PaymentStatus,
            
        };

        await dispatcher.Send(new CreateReservationCommand { Reservation = reservation });

        var response = new CreateReservationResponse
        {
            ReservationId = reservation.Id
        };

        return Results.Created($"api/v1/reservations/{response.ReservationId}", response);
    }
}




