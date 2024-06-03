using AutoMapper;
using Hotel_Reservation.Configuration;
using Hotel_Reservation.Extensions.Exceptions;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reservation.Domain;
using Reservation.Services.ReservationService;
using Reservation.Services.Rooms;
using System.Security.Claims;

namespace Hotel_Reservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController, Authorize]
	public class ReservationsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly UserResolverService _userResolverService;
		private readonly UserManager<User> _userManager;
		private readonly IReservationservices _reservationManager;
		private readonly IRoomservices _roomsManager;
		private readonly ISort<Reservations> _sort;
		private readonly ILogger<IReservationservices> _logger;
		public ReservationsController(
									 IMapper mapper,
									 UserResolverService userResolverService,
									 UserManager<User> userManager,
									 IReservationservices ReservationManager,
									 IRoomservices Roomservices,
									 ISort<Reservations> sort,
									 ILogger<IReservationservices> logger)
		{
			_mapper = mapper;
			_userResolverService = userResolverService;
			_userManager = userManager;
			_roomsManager = Roomservices;
			_sort = sort;
			_logger = logger;
			_reservationManager = ReservationManager;
		}
		[HttpGet("user-reservations")]
		public async Task<IActionResult> GetAllUserReservations([FromQuery] ReservationParameters reservationParameters)
		{
			// this method retrieves all reservations for a specified registered user and supports 
			// pagination, filtering and sorting
			var currentUser = _userResolverService.GetUser();
			var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
			User user = await _userManager.FindByIdAsync(currentUserName);

			var reservations = _reservationManager.Get(x => x.RegisteredUserId == user.Id);
			reservations = FilterReservations(ref reservations, reservationParameters);
			reservations = _sort.ApplySort(reservations, reservationParameters.OrderBy);
			var reservationCount=  PagedList<Reservations>.ToPagedList(reservations,
				reservationParameters.PageNumber,
				reservationParameters.PageSize);
			return Ok(reservationCount);
		}
		[HttpPost("addreservation")]
		public async Task<IActionResult> AddReservation([FromQuery] int roomId, [FromBody] ReservationDTO model)
		{
			/*
             * This method requires a room id and the starting and end date of a reservation as well as an optional note
             * that a user can leave to the hotel manager. It assigns a reservation to a specified room. 
             */
			var currentUser = _userResolverService.GetUser();
			var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
			User user = await _userManager.FindByIdAsync(currentUserName);
			if (_roomsManager.GetById(roomId) == null)
			{
				throw new NullReferenceException("The room that you requested does not exist.");
			}
			
			try
			{

				var Reservation = _mapper.Map<Reservations>(model);
				Reservation.CreationDate = DateTime.Now;
				Reservation.RegisteredUserId = user.Id;
				Reservation.ReservationStatusId = (int)ReservationStatusTypes.Processing;
				Reservation.RoomId = roomId;
				_reservationManager.Add(Reservation);
				return Ok(new { Reservations = true, data = Reservation });
			}
			catch (Exception ex)
			{
				return Ok(new { Reservations = false, error = ex.Message });
			}
		
		}
		[HttpPut("updatereservation")]
		public IActionResult UpdateReservationStatus([FromQuery] int id, [FromBody] int statusId)
		{
			// this method is used for a hotel manager to deny or approve a reservation or a registered user
			// to cancel the reservation
			var reservation = _reservationManager.GetById(id);
			if (statusId == 4)
			{
				if ((reservation.DateFrom - DateTime.Now).TotalDays > 3)
				{
					reservation.ReservationStatusId = statusId;
				}
				else
				{
					throw new BadRequestException("You cannot cancel this reservation because the cancellation period has ended.");
				}
			}
			else
			{
				reservation.ReservationStatusId = statusId;
			}

			_reservationManager.Update(reservation);
			_logger.LogInformation("Reservation status successfully updated!");
			return Ok("Reservation status updated successfully!");
		}
		private IQueryable<Reservations> FilterReservations(ref IQueryable<Reservations> reservations, ReservationParameters reservationParameters)
		{
			if (reservationParameters.ReservationStatus != null)
			{
				reservations = reservations.Where(r => r.ReservationStatus.Id == int.Parse(reservationParameters.ReservationStatus));
			}

			return reservations;
		}
		[HttpGet("RemoveReservations/{id}")]
		public IActionResult RemoveReservations(int id)
		{
			try
			{
				Reservations reservations = _reservationManager.GetById(id);
				if (reservations != null)
				{

					reservations.IsDeleted = true;
					reservations.ModificationDate = null;
					_reservationManager.Update(reservations);
					_logger.LogInformation("Reservation status successfully deleted!");
					return Ok(new { Reservations = true });
				}
				else
				{
					return Ok(new { Reservations = false, error = "Invalid Data" });
				}
			}
			catch (Exception ex)
			{
				return Ok(new { Reservations = false, error = ex.Message });
			}
		}
	}
}
