using Reservation.Core.Uow;
using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.Hotels
{
	public class HotelServices : IHotelservices
	{
		private readonly IUnitOfWork _unitOfWork;

		public HotelServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public bool Add(Hotel entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Hotel>();
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

		public IQueryable<Hotel> Get(Expression<Func<Hotel, bool>> predicate)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.FindBy(predicate);
		}
		public IQueryable<Hotel> Get(params Expression<Func<Hotel, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return (IQueryable<Hotel>)repository.Get(includes);

		}
		public IQueryable<Hotel> Get(Expression<Func<Hotel, bool>> predicate, params Expression<Func<Hotel, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return (IQueryable<Hotel>)repository.Get(predicate, includes);

		}

		public IList<Hotel> GetAll()
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.GetAll().OrderByDescending(x => x.Id).ToList();
		}


		public IQueryable<Hotel> GetAllIQueryable()
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.GetAll();
		}

		public Hotel GetById(int entityId)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.Get(entityId);
		}
		public bool Update(Hotel entityItem)
		{
			bool result = false;

			try
			{
				if (entityItem != null)
				{
					var repository = _unitOfWork.GetRepository<Hotel>();
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
		public IQueryable<Hotel> GetAll(string include)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.GetAll(include);
		}
		public IQueryable<Hotel> GetAll(string include, string include2)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.GetAll(include, include2);
		}

		public IQueryable<Hotel> GetAll(string include, string include2, string include3, string include4)
		{
			var repository = _unitOfWork.GetRepository<Hotel>();
			return repository.GetAll(include, include2, include3, include4);
		}

		public bool AddRange(List<Hotel> entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Hotel>();
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
		public void GetEditHotel(Hotel Modem, Hotel model)
		{
			if (Modem.Name != model.Name)
			{
				Modem.Name = model.Name;
			}
			if (Modem.ContactNumber != model.ContactNumber)
			{
				Modem.ContactNumber = model.ContactNumber;
			}
			if (Modem.CityId != model.CityId)
			{
				Modem.CityId = model.CityId;
			}
			if (Modem.Email != model.Email)
			{
				Modem.Email = model.Email;
			}
			if (Modem.Address != model.Address)
			{
				Modem.Address = model.Address;
			}

	}
		public bool HardDelete(Hotel entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//Logic

					var repository = _unitOfWork.GetRepository<Hotel>();
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
