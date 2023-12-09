namespace GondorsLegacy.Services.HotelInformation.Models;

public class SuccessResponseModel
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

}