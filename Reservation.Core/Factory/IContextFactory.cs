using Reservation.Core.EFContext;
using Reservation.Domain.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Reservation.Core.Factory
{
	/// <summary>
	/// context factory for ef
	/// </summary>
	public interface IContextFactory
	{
		IDatabaseContext DbContext { get; }
	}
}
