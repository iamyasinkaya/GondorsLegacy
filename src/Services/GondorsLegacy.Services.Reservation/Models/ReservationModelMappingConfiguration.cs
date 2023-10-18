using System;
namespace GondorsLegacy.Services.Reservation.Models
{
	public static class ReservationModelMappingConfiguration
	{
        public static ReservationModel ToModel(this Entities.Reservation entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ReservationModel
            {
                Id = entity.Id,
                CustomerFirstName = entity.CustomerFirstName,
                CustomerLastName = entity.CustomerLastName,
                CheckInDate = entity.CheckInDate,
                CheckOutDate = entity.CheckOutDate,
                RoomType = entity.RoomType,
                NumberOfGuests = entity.NumberOfGuests,
                RoomNumber = entity.RoomNumber,
                CustomerEmail = entity.CustomerEmail,
                ReservationStatus = entity.ReservationStatus,
                SpecialRequests = entity.SpecialRequests,
                NumberOfAdults = entity.NumberOfAdults,
                NumberOfChildren = entity.NumberOfChildren,
                PaymentStatus = entity.PaymentStatus,
                CancellationReason =entity.CancellationReason
               
            };
        }
    }
}

