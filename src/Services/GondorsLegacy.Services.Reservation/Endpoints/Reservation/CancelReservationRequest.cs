using Asp.Versioning;
using Asp.Versioning.Builder;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands.Reservation;
using GondorsLegacy.Services.Reservation.Constants;
using GondorsLegacy.Services.Reservation.Models;
using GondorsLegacy.Services.Reservation.Models.Requests.Reservation;
using GondorsLegacy.Services.Reservation.Models.Responses.Reservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints.Reservation;

public class CancelReservationRequestHandler : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        ApiVersionSet apiVersionSet = builder.NewApiVersionSet()
                                             .HasApiVersion(new ApiVersion(1))
                                             .HasApiVersion(new ApiVersion(2))
                                             .ReportApiVersions()
                                             .Build();
        builder.MapPost("api/v{version:apiVersion}/reservation/cancel", HandleAsync)
            .WithName("CancelReservation")
            .Produces<CancelReservationResponse>(statusCode: StatusCodes.Status201Created, contentType: "application/json")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new OpenApiOperation
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
            }).WithApiVersionSet(apiVersionSet).MapToApiVersion(1);
    }

    private static async Task<IActionResult> HandleAsync(IMediator dispatcher,
        [FromBody] CancelReservationRequest request)
    {
        try
        {
            if (request != null)
            {
                await dispatcher.Send(request: new CancelReservationCommand
                {
                    CustomerId = request.CustomerId,
                    IsReservationCancelled = request.IsReservationCancelled,
                    ReservationId = request.ReservationId
                });

                return new OkResult();
            }
            else
            {
                // Doğrulama hatası durumunda uygun bir hata yanıtı veriyoruz
                var errorDetails = new ErrorResponseModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = Messages.InvalidReservationRequestMessage,

                };

                // 400 Bad Request yanıtı dön
                return new BadRequestObjectResult(error: errorDetails);
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

            // 400 Bad Request yanıtı döndürün
            return new BadRequestObjectResult(error: errorResponse);
        }
    }
}