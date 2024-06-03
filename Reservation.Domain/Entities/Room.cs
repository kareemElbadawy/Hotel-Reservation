using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Domain
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
