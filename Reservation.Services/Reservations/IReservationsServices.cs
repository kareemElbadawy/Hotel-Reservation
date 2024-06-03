using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Services.ReservationService
{

	public interface IReservationservices
	{
		bool Add(Reservations entity);
		bool AddRange(List<Reservations> entity);

		bool Update(Reservations entity);
		IQueryable<Reservations> Get(params Expression<Func<Reservations, object>>[] includes);
		IQueryable<Reservations> Get(Expression<Func<Reservations, bool>> predicate, params Expression<Func<Reservations, object>>[] includes);
		IQueryable<Reservations> Get(Expression<Func<Reservations, bool>> predicate);

		IList<Reservations> GetAll();
		IQueryable<Reservations> GetAll(string include);
		IQueryable<Reservations> GetAll(string include, string include2);
		IQueryable<Reservations> GetAll(string include, string include2, string include3, string include4);

		IQueryable<Reservations> GetAllIQueryable();

		Reservations GetById(int entityId);
		void GetEditReservations(Reservations Reservations, Reservations model);
		bool HardDelete(Reservations model);


	}
}
