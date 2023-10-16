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
               
            };
        }
    }
}

