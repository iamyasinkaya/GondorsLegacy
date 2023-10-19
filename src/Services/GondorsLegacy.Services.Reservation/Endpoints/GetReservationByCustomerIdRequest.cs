using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Models;
using GondorsLegacy.Services.Reservation.Queries;
using MediatR;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints;

public class GetReservationByCustomerIdRequest : IEndpointHandler
{
 public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("api/v1/reservation/customer/{customerId}", HandleAsync)
            .WithMetadata(new OpenApiOperation
            {
                OperationId = "GetReservationCustomerId",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Reservations" } },
                Parameters = new List<OpenApiParameter>
                {
                new OpenApiParameter
                {
                    Name = "customerId",
                    In = ParameterLocation.Path,
                    Required = true,
                    Description = "Customer ID",
                    Schema = new OpenApiSchema { Type = "string", Format = "guid" }
                }
                },
                Responses = new OpenApiResponses
                {
                    // 200 OK yanıtı
                    ["200"] = new OpenApiResponse
                    {
                        Description = "Reservation details retrieved successfully",
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            ["application/json"] = new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema { /* JSON şeması eklenecek */ }
                            }
                        }
                    },
                    // 404 Not Found yanıtı
                    ["404"] = new OpenApiResponse
                    {
                        Description = "Reservation not found"
                    }
                }
            });
    }



    private static async Task<IResult> HandleAsync(IMediator dispatcher, Guid customerId)
    {
        var reservation = await dispatcher.Send(new GetReservationByCustomerIdQuery { CustomerId = customerId, ThrowNotFoundIfNull = true });
        var model = reservation.ToModel();
        return Results.Ok(model);
    }
}