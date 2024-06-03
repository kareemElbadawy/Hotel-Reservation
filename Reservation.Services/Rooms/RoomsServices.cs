using Reservation.Core.Uow;
using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.Rooms
{
	public class RoomServices : IRoomservices
	{
		private readonly IUnitOfWork _unitOfWork;

		public RoomServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public bool Add(Room entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Room>();
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

		public IQueryable<Room> Get(Expression<Func<Room, bool>> predicate)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.FindBy(predicate);
		}
		public IQueryable<Room> Get(params Expression<Func<Room, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return (IQueryable<Room>)repository.Get(includes);

		}
		public IQueryable<Room> Get(Expression<Func<Room, bool>> predicate, params Expression<Func<Room, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return (IQueryable<Room>)repository.Get(predicate, includes);

		}

		public IList<Room> GetAll()
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.GetAll().OrderByDescending(x => x.Id).ToList();
		}


		public IQueryable<Room> GetAllIQueryable()
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.GetAll();
		}

		public Room GetById(int entityId)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.Get(entityId);
		}
		public bool Update(Room entityItem)
		{
			bool result = false;

			try
			{
				if (entityItem != null)
				{
					var repository = _unitOfWork.GetRepository<Room>();
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
		public IQueryable<Room> GetAll(string include)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.GetAll(include);
		}
		public IQueryable<Room> GetAll(string include, string include2)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.GetAll(include, include2);
		}

		public IQueryable<Room> GetAll(string include, string include2, string include3, string include4)
		{
			var repository = _unitOfWork.GetRepository<Room>();
			return repository.GetAll(include, include2, include3, include4);
		}

		public bool AddRange(List<Room> entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Room>();
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
		public void GetEditRoom(Room Modem, Room model)
		{
			if (Modem.Name != model.Name)
			{
				Modem.Name = model.Name;
			}
			
			if (Modem.NumberOfBeds != model.NumberOfBeds)
			{
				Modem.NumberOfBeds = model.NumberOfBeds;
			}
			if (Modem.Price != model.Price)
			{
				Modem.Price = model.Price;
			}
			if (Modem.HotelId != model.HotelId)
			{
				Modem.HotelId = model.HotelId;
			}

	}
		public bool HardDelete(Room entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Room>();
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
