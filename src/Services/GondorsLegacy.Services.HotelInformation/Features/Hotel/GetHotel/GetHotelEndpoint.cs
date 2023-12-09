using AutoMapper;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.HotelInformation.Constants;
using GondorsLegacy.Services.HotelInformation.Models;
using MediatR;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.HotelInformation.Features.Hotel.GetHotel;

public class GetHotelEndpoint : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("api/v1/hotel/{id}", HandleAsync)
            .WithMetadata(new OpenApiOperation
            {
                OperationId = "GetHotel",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Hotels" } },
                Parameters = new List<OpenApiParameter>
                {
                new OpenApiParameter
                {
                    Name = "id",
                    In = ParameterLocation.Path,
                    Required = true,
                    Description = "Hotel ID",
                    Schema = new OpenApiSchema { Type = "string", Format = "guid" }
                }
                }
            });
    }
    private static async Task<IResult> HandleAsync(IMediator dispatcher, Guid id, IMapper mapper)
    {
        Entities.Hotel hotel = await dispatcher.Send(new GetHotelQuery { Id = id, ThrowNotFoundIfNull = true });

        if (hotel == null)
        {
            // Hotel not found, return 404 Not Found response with details

            return Results.NotFound(new ErrorResponseModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = Messages.HotelNotFound,
            });
        }
        var mappingModel = mapper.Map<HotelResponse>(hotel);

        var response = new SuccessResponseModel
        {
            StatusCode = StatusCodes.Status200OK,
            Message = Messages.RequestProcessedSuccessfully,
            Data = mappingModel
        };

        return Results.Ok(response);
    }

}
