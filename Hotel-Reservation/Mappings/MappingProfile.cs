using AutoMapper;
using static Azure.Core.HttpHeader;
using System.Data;
using System.Security.Policy;
using Reservation.Domain;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			CreateMap<RegisterHotelDTO, Hotel>();
			CreateMap<Hotel, RegisterHotelDTO>();
			CreateMap<AddRoomDTO, Room>();
			CreateMap<Room, AddRoomDTO>();
			CreateMap<ReservationDTO, Reservations>();
			CreateMap<Reservations, ReservationDTO>();

		}
	}

}
