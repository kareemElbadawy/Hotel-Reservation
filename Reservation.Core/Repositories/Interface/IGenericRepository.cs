﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Repositories.Interface
{
	/// <summary>
	/// Interface for generic repository for crud operations
	/// </summary>
	public interface IGenericRepository<T>
	{
		/// <returns>The Entity's state</returns>
		EntityState Add(T entity);
		/// <returns>The Entity's state</returns>
		EntityState Update(T entity);
		/// <returns>Entity</returns>
		T Get<TKey>(TKey id);

		/// <returns>Task Entity</returns>
		Task<T> GetAsync<TKey>(TKey id);

		/// <returns>The requested Entity</returns>
		T Get(params object[] keyValues);

		/// <returns>Entity</returns>
		IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

		/// <returns>Queryable</returns>
		IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);

		/// <returns>List of entities</returns>
		IQueryable<T> GetAll();

		/// <returns>Queryable</returns>
		IQueryable<T> GetAll(int page, int pageCount);

		/// <returns>List of entities</returns>
		IQueryable<T> GetAll(string include);

		/// <returns>List of entities</returns>
		IQueryable<T> Get(params Expression<Func<T, object>>[] includes);

		IQueryable<T> RawSql(string sql, params object[] parameters);

		/// <returns>List of entities</returns>
		IQueryable<T> GetAll(string include, string include2);
		IQueryable<T> GetAll(string include, string include2, string include3, string include4);

		/// <summary>
		/// Soft delete with using IsActive flag for entity
		/// </summary>
		/// <returns>The Entity's state</returns>
		EntityState SoftDelete(T entity);

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <returns>The Entity's state</returns>
		EntityState HardDelete(T entity);

		bool Exists(Expression<Func<T, bool>> predicate);
		void AddRange(List<T> entity);



	}

}
