using System;

namespace GondorsLegacy.Services.External
{
    public class Property
    {
        public int ExternalPropertyId { get; set; } // int32 (not nullable)
        public string Name { get; set; } // string | null
        public string InternalName { get; set; } // string | null
        public string Description { get; set; } // string | null
        public double Latitude { get; set; } // double (not nullable)
        public double Longitude { get; set; } // double (not nullable)
        public string Address { get; set; } // string | null
        public bool HideAddress { get; set; } // boolean (not nullable)
        public string Zip { get; set; } // string | null
        public string City { get; set; } // string | null
        public string State { get; set; } // string | null
        public string Country { get; set; } // string | null
        public string PhoneNumber { get; set; } // string | null - Contact number for the property
        public string Email { get; set; } // string | null - Contact email for the property
        public string Website { get; set; } // string | null - Website URL for the property
        public bool IsAvailable { get; set; } // boolean (not nullable) - Availability status
        public decimal PricePerNight { get; set; } // decimal (not nullable) - Price per night
        public int MaxGuests { get; set; } // int32 (not nullable) - Maximum number of guests allowed
        public int Bedrooms { get; set; } // int32 (not nullable) - Number of bedrooms
        public int Bathrooms { get; set; } // int32 (not nullable) - Number of bathrooms
        public int TotalAreaInSqFt { get; set; } // int32 (not nullable) - Total area in square feet
        public bool IsPetFriendly { get; set; } // boolean (not nullable) - Whether the property is pet-friendly
        public string PropertyType { get; set; } // string | null - Type of property (e.g., house, apartment, etc.)
        public string Amenities { get; set; } // string | null - A comma-separated list of amenities
        public DateTime DateListed { get; set; } // DateTime (not nullable) - When the property was listed
        public string OwnerName { get; set; } // string | null - Name of the property owner
        public string OwnerContact { get; set; } // string | null - Contact information for the owner
        public string PropertyImagesUrl { get; set; } // string | null - URLs to images of the property
        public string CheckInTime { get; set; } // string | null - Check-in time for the property
        public string CheckOutTime { get; set; } // string | null - Check-out time for the property
        public bool IsVerified { get; set; } // boolean (not nullable) - Whether the property is verified
        public double Rating { get; set; } // double (not nullable) - Property rating (e.g., based on reviews)
        public string Currency { get; set; } // string | null - Currency for the pricing (e.g., USD, EUR)
    }
}
