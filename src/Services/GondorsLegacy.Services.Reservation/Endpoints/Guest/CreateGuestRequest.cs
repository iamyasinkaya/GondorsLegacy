using Asp.Versioning;
using Asp.Versioning.Builder;
using AutoMapper;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.Reservation.Commands.Guest;
using GondorsLegacy.Services.Reservation.Constants;
using GondorsLegacy.Services.Reservation.Models;
using GondorsLegacy.Services.Reservation.Models.Requests.Guest;
using GondorsLegacy.Services.Reservation.Models.Responses.Guest;
using GondorsLegacy.Services.Reservation.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.Reservation.Endpoints.Guest;



public class CreateGuestRequestHandler : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        ApiVersionSet apiVersionSet = builder.NewApiVersionSet()
                                             .HasApiVersion(new ApiVersion(1))
                                             .HasApiVersion(new ApiVersion(2))
                                             .ReportApiVersions()
                                             .Build();

        builder.MapPost("api/v{version:apiVersion}/guest/create", HandleAsync)
            .WithName("CreateGuest")
            .Produces<CreateGuestResponse>(statusCode: StatusCodes.Status201Created, contentType: "application/json")
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
                                Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "CreateGuestRequest" }
                            }
                        }
                    },
                    Required = true
                }
            }).WithApiVersionSet(apiVersionSet).MapToApiVersion(1);
    }

    private static async Task<IResult> HandleAsync(IMediator dispatcher, [FromBody] CreateGuestRequest request, IMapper mapper)
    {
        try
        {
            var guest = mapper.Map<Entities.Guest>(request);

            var validator = new GuestValidator();

            var result = validator.Validate(guest);

            if (result.IsValid)
            {
                await dispatcher.Send(new CreateGuestCommand { Guest = guest });

                var guestResponse = new CreateGuestResponse
                {
                    GuestId = guest.Id
                };
                var response = new SuccessResponseModel
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = Messages.RequestProcessedSuccessfully,
                    Data = guestResponse
                };
                // İşlem başarılı olduğunda 201 Created yanıtı dön
                return Results.Created($"api/v{{version:apiVersion}}/guests/{guestResponse.GuestId}", response);
            }
            else
            {
                // Doğrulama hatası durumunda uygun bir hata yanıtı veriyoruz
                var errorDetails = new ErrorResponseModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = Messages.InvalidReservationRequestMessage,
                    ErrorDetails = result.Errors.Select(error => error.ErrorMessage).ToList()
                };

                // 400 Bad Request yanıtı dön
                return Results.BadRequest(error: errorDetails);
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