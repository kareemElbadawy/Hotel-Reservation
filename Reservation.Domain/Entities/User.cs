using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Reservation.Domain
{
	public class User : IdentityUser
	{
        public virtual ICollection<HotelUser> HotelUsers { get; set; }
    }
}
