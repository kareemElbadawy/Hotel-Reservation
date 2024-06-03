using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.Hotels
{

	public interface IHotelservices
	{
		bool Add(Hotel entity);
		bool AddRange(List<Hotel> entity);

		bool Update(Hotel entity);
		IQueryable<Hotel> Get(params Expression<Func<Hotel, object>>[] includes);
		IQueryable<Hotel> Get(Expression<Func<Hotel, bool>> predicate, params Expression<Func<Hotel, object>>[] includes);
		IQueryable<Hotel> Get(Expression<Func<Hotel, bool>> predicate);

		IList<Hotel> GetAll();
		IQueryable<Hotel> GetAll(string include);
		IQueryable<Hotel> GetAll(string include, string include2);
		IQueryable<Hotel> GetAll(string include, string include2, string include3, string include4);

		IQueryable<Hotel> GetAllIQueryable();

		Hotel GetById(int entityId);
		void GetEditHotel(Hotel Hotel, Hotel model);
		bool HardDelete(Hotel model);


	}
}
