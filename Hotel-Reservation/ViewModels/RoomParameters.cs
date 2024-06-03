﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Models
{
    public class RoomParameters : BasePagingModel
    {
        public RoomParameters()
        {
            OrderBy = "Price";
        }
        public int? City { get; set; }
        public uint NumberOfBeds { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? HotelId { get; set; }
        public int Price { get; set; }
    }
}
