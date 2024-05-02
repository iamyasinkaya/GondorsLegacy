using GondorsLegacy.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace GondorsLegacy.Services.Reservation.Entities;

public class Guest : Entity<Guid>
{
    private string _firstName;
    private string _lastName;

    public string Firstname
    {
        get => _firstName;
        set => _firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }

    public string Lastname
    {
        get => _lastName;
        set => _lastName = value.ToUpper();
    }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string EmailAddress { get; set; }
    public Guid ReservationId { get; set; }

    [NotMapped]
    public int Age => CalculateAge();


    private int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}
