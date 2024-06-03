using Reservation.Core.Uow;
using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.ReservationService
{
	public class ReservationsServices : IReservationservices
	{
		private readonly IUnitOfWork _unitOfWork;

		public ReservationsServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public bool Add(Reservations entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Reservations>();
					repository.Add(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}

		public IQueryable<Reservations> Get(Expression<Func<Reservations, bool>> predicate)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.FindBy(predicate);
		}
		public IQueryable<Reservations> Get(params Expression<Func<Reservations, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return (IQueryable<Reservations>)repository.Get(includes);

		}
		public IQueryable<Reservations> Get(Expression<Func<Reservations, bool>> predicate, params Expression<Func<Reservations, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return (IQueryable<Reservations>)repository.Get(predicate, includes);

		}

		public IList<Reservations> GetAll()
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.GetAll().OrderByDescending(x => x.Id).ToList();
		}


		public IQueryable<Reservations> GetAllIQueryable()
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.GetAll();
		}

		public Reservations GetById(int entityId)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.Get(entityId);
		}
		public bool Update(Reservations entityItem)
		{
			bool result = false;

			try
			{
				if (entityItem != null)
				{
					var repository = _unitOfWork.GetRepository<Reservations>();
					repository.Update(entityItem);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return result;
				//throw;
			}

			return result;
		}
		public IQueryable<Reservations> GetAll(string include)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.GetAll(include);
		}
		public IQueryable<Reservations> GetAll(string include, string include2)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.GetAll(include, include2);
		}

		public IQueryable<Reservations> GetAll(string include, string include2, string include3, string include4)
		{
			var repository = _unitOfWork.GetRepository<Reservations>();
			return repository.GetAll(include, include2, include3, include4);
		}

		public bool AddRange(List<Reservations> entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Reservations>();
					repository.AddRange(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}
		public void GetEditReservations(Reservations Modem, Reservations model)
		{
			if (Modem.DateFrom != model.DateFrom)
			{
				Modem.DateFrom = model.DateFrom;
			}
			
			if (Modem.DateTo != model.DateTo)
			{
				Modem.DateTo = model.DateTo;
			}
			if (Modem.Note != model.Note)
			{
				Modem.Note = model.Note;
			}
			if (Modem.RegisteredUserId != model.RegisteredUserId)
			{
				Modem.RegisteredUserId = model.RegisteredUserId;
			}
			if (Modem.RoomId != model.RoomId)
			{
				Modem.RoomId = model.RoomId;
			}
			

	}
		public bool HardDelete(Reservations entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Reservations>();
					repository.HardDelete(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}

	}

}
