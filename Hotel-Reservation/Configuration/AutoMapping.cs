using AutoMapper;
using Hotel_Reservation.Models;
using Reservation.Domain;


namespace Hotel_Reservation.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RegisterHotelDTO, Hotel>();
            CreateMap<AddRoomDTO, Room>();
            CreateMap<ReservationDTO, Reservations>();
        }
    }
}
