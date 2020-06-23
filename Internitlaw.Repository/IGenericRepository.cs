using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Internitlaw.Repository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Get all the entities
		/// </summary>
		/// <returns></returns>
		IQueryable<TEntity> GetAll();
		/// <summary>
		/// Get query for entity
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="orderBy"></param>
		/// <returns></returns>
		IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
		/// <summary>
		/// Get first or default entity by filter
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
		/// <summary>
		/// Get Entity by Id and include related navigation properties
		/// </summary>
		/// <param name="id"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		Task<TEntity> GetById(int id, string[] includes = null);
		/// <summary>
		/// Insert a new entity to database
		/// </summary>
		/// <param name="entity"></param>
		Task<TEntity> Create(TEntity entity);
		/// <summary>
		/// Update entity in database
		/// </summary>
		/// <param name="entity"></param>
		Task<int> Update(TEntity entity);
		/// <summary>
		/// Delete entity from database by primary key
		/// </summary>
		/// <param name="id"></param>
		Task<int> Delete(int id);
	}
}
