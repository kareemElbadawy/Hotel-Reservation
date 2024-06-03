using System;

namespace Hotel_Reservation.Models
{
    public class ReservationParameters : BasePagingModel
    {
        public ReservationParameters()
        {
            OrderBy = "CreationDate";
        }

        public DateTime CreationDate { get; set; }
        public string ReservationStatus { get; set; }
    }
}
