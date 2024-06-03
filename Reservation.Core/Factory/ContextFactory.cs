using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Reservation.Core.EFContext;
using Reservation.Domain.Configuration;
using System;
using System.Data.SqlClient;

namespace Reservation.Core.Factory
{
	public class ContextFactory : IContextFactory
	{
		private readonly IOptions<ConnectionSettings> _connectionOptions;

		public ContextFactory(IOptions<ConnectionSettings> connectionOptions)
		{
			_connectionOptions = connectionOptions;
		}

		public IDatabaseContext DbContext => new DatabaseContext(GetDataContext().Options);

		private DbContextOptionsBuilder<DatabaseContext> GetDataContext()
		{
			ValidateDefaultConnection();

			var sqlConnectionBuilder = new SqlConnectionStringBuilder(_connectionOptions.Value.DefaultConnection);

			var contextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

			contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

			return contextOptionsBuilder;
		}

		private void ValidateDefaultConnection()
		{
			if (string.IsNullOrEmpty(_connectionOptions.Value.DefaultConnection))
			{
				throw new ArgumentNullException(nameof(_connectionOptions.Value.DefaultConnection));
			}
		}
	}

}
