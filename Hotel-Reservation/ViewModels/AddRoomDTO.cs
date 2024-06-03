using System.Collections.Generic;

namespace Hotel_Reservation.Models
{
    public class AddRoomDTO
    {
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }
    }
}
