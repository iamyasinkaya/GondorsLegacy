using Asp.Versioning;
using Asp.Versioning.Builder;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands.Guest;
using GondorsLegacy.Services.Reservation.Models.Requests.Guest;
using GondorsLegacy.Services.Reservation.Models.Responses.Guest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints.Guest;

public class UpdateGuestRequestHandler : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        ApiVersionSet apiVersionSet = builder.NewApiVersionSet()
                                            .HasApiVersion(new ApiVersion(1))
                                            .HasApiVersion(new ApiVersion(2))
                                            .ReportApiVersions()
                                            .Build();

        builder.MapPut("api/v{version:apiVersion}/guest/update", HandleAsync)
             .WithName("UpdateGuest")
             .Produces<UpdateGuestResponse>(statusCode: StatusCodes.Status200OK, contentType: "application/json")
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithOpenApi(operation => new OpenApiOperation
             {
                 Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Guests" } },
                 RequestBody = new OpenApiRequestBody
                 {
                     Content = new Dictionary<string, OpenApiMediaType>
                     {
                         ["application/json"] = new OpenApiMediaType
                         {
                             Schema = new OpenApiSchema
                             {
                                 Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "UpdateGuestRequest" }
                             }
                         }
                     },
                     Required = true
                 }
             }).WithApiVersionSet(apiVersionSet).MapToApiVersion(1);
    }

    private static async Task<IResult> HandleAsync(IMediator dispatcher, [FromBody] UpdateGuestRequest request)
    {
        try
        {

             await dispatcher.Send(new UpdateGuestCommand { Guest = request.Guest });

            return Results.Ok(request.Guest.Id);

        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);

        }
    }
}
