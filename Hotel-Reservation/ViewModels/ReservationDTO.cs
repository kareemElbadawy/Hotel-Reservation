using System;
namespace Hotel_Reservation.Models
{
    public class ReservationDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
    }
}
