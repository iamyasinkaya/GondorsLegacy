namespace GondorsLegacy.Services.Reservation.Entities;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public List<string> ErrorDetails { get; set; }
}