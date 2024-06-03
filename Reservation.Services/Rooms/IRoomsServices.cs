using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.Rooms
{

	public interface IRoomservices
	{
		bool Add(Room entity);
		bool AddRange(List<Room> entity);

		bool Update(Room entity);
		IQueryable<Room> Get(params Expression<Func<Room, object>>[] includes);
		IQueryable<Room> Get(Expression<Func<Room, bool>> predicate, params Expression<Func<Room, object>>[] includes);
		IQueryable<Room> Get(Expression<Func<Room, bool>> predicate);

		IList<Room> GetAll();
		IQueryable<Room> GetAll(string include);
		IQueryable<Room> GetAll(string include, string include2);
		IQueryable<Room> GetAll(string include, string include2, string include3, string include4);

		IQueryable<Room> GetAllIQueryable();

		Room GetById(int entityId);
		void GetEditRoom(Room Room, Room model);
		bool HardDelete(Room model);


	}
}
