using AutoMapper;
using Castle.DynamicProxy;
using GondorsLegacy.Application.Common.Services;
using GondorsLegacy.CrossCuttingCorners.Exceptions;
using GondorsLegacy.Infrastructure.Interceptors;
using GondorsLegacy.Infrastructure.Web.MinimalApis;
using GondorsLegacy.Services.HotelInformation.Constants;
using GondorsLegacy.Services.HotelInformation.Entities;
using GondorsLegacy.Services.HotelInformation.Features.Hotel.GetHotel;
using GondorsLegacy.Services.HotelInformation.Models;
using GondorsLegacy.Services.HotelInformation.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace GondorsLegacy.Services.HotelInformation.Features.Hotel.UpdateHotel;

public class UpdateHotelRequest
{
    public string Name
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }
}

public class UpdateHotelResponse
{
    public string Name
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }
}

public class UpdateHotelCommand : IRequest
{
    public Entities.Hotel Hotel
    {
        get;
        set;
    }
}

public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
{
    private readonly ICrudService<Entities.Hotel> _hotelService;
    private readonly ILogger<UpdateHotelCommand> _logger;
    private readonly IProxyGenerator _proxyGenerator;
    private readonly LoggingInterceptor _interceptor;

    public UpdateHotelCommandHandler(ICrudService<Entities.Hotel> hotelService,
      ILogger<UpdateHotelCommand> logger,
      IProxyGenerator proxyGenerator,
      LoggingInterceptor interceptor)
    {
        _hotelService = hotelService;
        _logger = logger;
        _proxyGenerator = proxyGenerator;
        _interceptor = interceptor;
    }

    public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget(_hotelService, _interceptor);

            var existingHotel = await proxy.GetByIdAsync(request.Hotel.Id, cancellationToken);

            if (existingHotel == null)
            {
                throw new NotFoundException();
            }

            existingHotel.Name = request.Hotel.Name;
            existingHotel.Description = request.Hotel.Description;
            // Diğer özellikleri de aynı şekilde güncelle

            await proxy.UpdateAsync(existingHotel, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public class UpdateHotelEndpoint : IEndpointHandler
{
    public static void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPut("api/v1/hotel/update/{hotelId}", HandleAsync)
          .WithName("UpdateHotel")
          .Produces<UpdateHotelResponse>(statusCode: StatusCodes.Status200OK, contentType: "application/json")
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithOpenApi(operation => new Microsoft.OpenApi.Models.OpenApiOperation
          {
              Tags = new List<OpenApiTag> {
            new OpenApiTag {
              Name = "Hotels"
            }
              },
              Parameters = new List<OpenApiParameter> {
            new OpenApiParameter {
              Name = "hotelId",
                In = ParameterLocation.Path,
                Required = true,
                Schema = new OpenApiSchema {
                  Type = "string", // Eğer hotelId bir string ise; tipini değiştirebilirsiniz.
                    Format = "uuid" // Eğer hotelId bir Guid ise, tip formatını "uuid" olarak belirtin.
                }
            }
              },
              RequestBody = new OpenApiRequestBody
              {
                  Content = new Dictionary<string, OpenApiMediaType>
                  {
                      ["application/json"] = new OpenApiMediaType
                      {
                          Schema = new OpenApiSchema
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.Schema,
                                  Id = "UpdateHotelRequest"
                              }
                          }
                      }
                  },
                  Required = true
              }
          });
    }

    private static async Task<IResult> HandleAsync(IMediator dispatcher, [FromBody] UpdateHotelRequest request, Guid hotelId, IMapper mapper)
    {
        try
        {
            Entities.Hotel hotel = mapper.Map<Entities.Hotel>(request);
            hotel.Id = hotelId;

            HotelValidator validator = new HotelValidator();

            var result = validator.Validate(hotel);

            if (result.IsValid)
            {
                await dispatcher.Send(new UpdateHotelCommand
                {
                    Hotel = hotel
                });

                var response = new SuccessResponseModel
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = Messages.HotelUpdatedSuccessfully,
                    Data = new UpdateHotelResponse
                    {
                        Description = request.Description,
                        Name = request.Name
                    }
                };

                return Results.Ok(response);
            }
            else
            {

                ErrorResponseModel errorDetails = new ErrorResponseModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = Messages.InvalidHotelRequestMessage,
                    ErrorDetails = result.Errors.Select(error => error.ErrorMessage).ToList()
                };

                return Results.BadRequest(error: errorDetails);
            }
        }
        catch (Exception ex)
        {
            var errorResponse = new ErrorResponseModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = Messages.DefaultErrorMessage,
                ErrorDetails = new List<string> { ex.Message }
            };

            return Results.BadRequest();
        }
    }
}