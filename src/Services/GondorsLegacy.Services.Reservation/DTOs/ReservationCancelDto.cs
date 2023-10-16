using System;
using GondorsLegacy.Services.Reservation.Constants;

namespace GondorsLegacy.Services.Reservation.DTOs
{
	public class ReservationCancelDto
	{
        public CancellationReason CancellationReason { get; set; } // İptal nedeni

    }
}

