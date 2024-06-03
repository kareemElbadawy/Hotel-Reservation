using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Domain
{
    public class ReservationStatus : BaseEntity
    {
        public string Name { get; set; }
        
        public virtual ICollection<Reservations> Reservations { get; set; }

    }
}
