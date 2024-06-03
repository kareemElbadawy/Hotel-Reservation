using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Domain
{
    public class Reservations : BaseEntity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
        public string RegisteredUserId { get; set; }
        public int RoomId { get; set; }
        public int ReservationStatusId { get; set; }
        [ForeignKey("RegisteredUserId")]
        public virtual User RegisteredUser { get; set; }
		[ForeignKey("RoomId")]
		public virtual Room Room { get; set; }
		[ForeignKey("ReservationStatusId")]
		public virtual ReservationStatus ReservationStatus { get; set;  }

    }
}
