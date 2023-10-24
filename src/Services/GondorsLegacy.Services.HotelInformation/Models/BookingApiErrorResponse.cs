using System;
namespace GondorsLegacy.Services.HotelInformation.Models;

public class BookingApiErrorResponse
{
    public string Message { get; set; }
    public List<ErrorDetail> Errors { get; set; }
    public string Code { get; set; }
}

public class ErrorDetail
{
    public string Field { get; set; }
    public string Message { get; set; }
}
