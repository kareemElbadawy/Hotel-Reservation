using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Domain
{
    public class HotelUser : BaseEntity
    {
        public int HotelId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
		[ForeignKey("UserId")]
		public virtual User User { get; set; }


    }
}
