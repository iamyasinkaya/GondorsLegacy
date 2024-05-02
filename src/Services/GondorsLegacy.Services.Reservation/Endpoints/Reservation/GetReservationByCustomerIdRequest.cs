using Asp.Versioning.Builder;
using Asp.Versioning;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Models;
using GondorsLegacy.Services.Reservation.Queries;
using MediatR;
using Microsoft.OpenApi.Models;
using GondorsLegacy.Services.Reservation.Constants;
using GondorsLegacy.Services.Reservation.Queries.Reservation;

namespace GondorsLegacy.Services.Reservation.Endpoints.Reservation;

public class GetReservationByCustomerIdRequest : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        ApiVersionSet apiVersionSet = builder.NewApiVersionSet()
                                             .HasApiVersion(new ApiVersion(1))
                                             .HasApiVersion(new ApiVersion(2))
                                             .ReportApiVersions()
                                             .Build();
        builder.MapGet("api/v{version:apiVersion}/reservation/customer/{customerId}", HandleAsync)
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
            }).WithApiVersionSet(apiVersionSet).MapToApiVersion(1);
    }



    private static async Task<IResult> HandleAsync(IMediator dispatcher, Guid customerId)
    {
        var reservation = await dispatcher.Send(new GetReservationByCustomerIdQuery { CustomerId = customerId, ThrowNotFoundIfNull = true });
        if (reservation == null)
        {
            // Hotel not found, return 404 Not Found response with details

            return Results.NotFound(new ErrorResponseModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = Messages.ResourceNotFoundMessage,
            });
        }
        var model = reservation.ToModel();
        var response = new SuccessResponseModel
        {
            StatusCode = StatusCodes.Status200OK,
            Message = Messages.RequestProcessedSuccessfully,
            Data = model
        };
        return Results.Ok(response);
    }
}