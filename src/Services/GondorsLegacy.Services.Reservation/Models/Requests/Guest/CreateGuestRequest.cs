namespace GondorsLegacy.Services.Reservation.Models.Requests.Guest;

public class CreateGuestRequest
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string EmailAddress { get; set; }
    public Guid ReservationId { get; set; }
}
