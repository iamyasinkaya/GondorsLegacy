namespace GondorsLegacy.Services.Reservation.Models;

public class ErrorResponseModel
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public List<string> ErrorDetails { get; set; }
}