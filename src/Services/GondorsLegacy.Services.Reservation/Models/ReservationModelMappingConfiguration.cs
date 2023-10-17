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
                CustomerName = entity.CustomerName,
                CheckInDate = entity.CheckInDate,
                CheckOutDate = entity.CheckOutDate,
                RoomType = entity.RoomType,
                NumberOfGuests = entity.NumberOfGuests,
                TotalPrice = entity.TotalPrice,
                RoomNumber = entity.RoomNumber,
                CustomerEmail = entity.CustomerEmail,
                ReservationStatus = entity.ReservationStatus,
                PaymentInformation = entity.PaymentInformation,
                SpecialRequests = entity.SpecialRequests,
                NumberOfAdults = entity.NumberOfAdults,
                NumberOfChildren = entity.NumberOfChildren,
                TaxRate = entity.TaxRate,
                ExtraServicePrice = entity.ExtraServicePrice,
                ExtraServices =  entity.ExtraServices,
                PaymentStatus = entity.PaymentStatus,
                CancellationReason =entity.CancellationReason
               
            };
        }
    }
}

