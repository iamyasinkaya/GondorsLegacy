using GondorsLegacy.Domain.Entities;

namespace GondorsLegacy.Services.HotelInformation;

public sealed class Address : Entity<Guid>
{
    public Guid HotelId { get; set; }
    // Temel adres bilgileri
    public string? Country { get; set; }        // Ülke
    public string? Province { get; set; }       // İl / Eyalet
    public string? District { get; set; }       // İlçe / Semt
    public string? City { get; set; }           // Şehir
    public string? PostCode { get; set; }       // Posta Kodu
    public string? Neighborhood { get; set; }   // Mahalle
    public string? Street { get; set; }         // Cadde / Sokak
    public string? AdditionalInfo { get; set; } // Ek Bilgi

    // Ekstra adres detayları
    public string? BuildingNumber { get; set; }      // Bina Numarası
    public string? Floor { get; set; }              // Kat
    public string? ApartmentNumber { get; set; }    // Daire Numarası
    public string? POBox { get; set; }              // Posta Kutusu
   

    // Coğrafi koordinatlar
    public double Latitude { get; set; }            // Enlem
    public double Longitude { get; set; }           // Boylam

    // Güvenlik detayları
    public bool IsSecure { get; set; }              // Güvenli Adres mi?
    public string? SecurityCode { get; set; }        // Güvenlik Kodu

    // Özel etiketler
    public string? Labels { get; set; }         // Adrese özel etiketler (Örn: Ev, İş, vs.)

}