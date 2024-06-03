using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Domain
{
    public class Hotel : BaseEntity
	{
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual ICollection<HotelUser> HotelUsers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
