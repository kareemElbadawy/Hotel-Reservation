using Reservation.Core.EFContext;
using Reservation.Core.Repositories.Interface;
using Reservation.Domain;

namespace Reservation.Core.Uow
{
	public interface IUnitOfWork
	{
		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
		int Commit();
		/// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
		Task<int> CommitAsync();
		/// <returns>Repository</returns>
		IGenericRepository<TEntity> GetRepository<TEntity>()
			where TEntity : BaseEntity;
		IDatabaseContext Context { get; }
	}
}
