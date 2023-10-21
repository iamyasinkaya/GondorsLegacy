using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands;
using GondorsLegacy.Services.Reservation.Constants;
using GondorsLegacy.Services.Reservation.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints;

public class CancelReservationRequest
{
    public Guid ReservationId { get; set; } // Rezervasyon kimliği
    public Guid CustomerId { get; set; } // Müşteri kimliği
    public bool IsReservationCancelled { get; set; }
}
public class CancelReservationResponse
{

}

public class CancelReservationRequestHandler : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("api/v1/reservations/cancel", HandleAsync)
            .WithName("CancelReservation")
            .Produces<CancelReservationResponse>(statusCode: StatusCodes.Status201Created, contentType: "application/json")
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
                                Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "CancelReservationRequest" }
                            }
                        }
                    },
                    Required = true
                }
            });
    }

    private static async Task<IActionResult> HandleAsync(IMediator dispatcher,
        [FromBody] CancelReservationRequest request)
    {
        try
        {
            if (request != null)
            {
                await dispatcher.Send(new CancelReservationCommand
                { CustomerId = request.CustomerId, IsReservationCancelled = request.IsReservationCancelled, ReservationId = request.ReservationId });

                return new OkResult();
            }
            else
            {
                // Doğrulama hatası durumunda uygun bir hata yanıtı veriyoruz
                var errorDetails = new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = Messages.InvalidReservationRequestMessage,

                };

                // 400 Bad Request yanıtı dön
                return new BadRequestObjectResult(error:errorDetails);
            }
        }
        catch (Exception ex)
        {
            // Diğer hata durumları için uygun bir hata yanıtı verin
            var errorResponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = Messages.DefaultErrorMessage,
                ErrorDetails = new List<string> { ex.Message }
            };

            // 400 Bad Request yanıtı döndürün
            return new BadRequestObjectResult(error:errorResponse);
        }
    }
}