using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.EFContext;
using Internitlaw.Repository.Extensions;

namespace Internitlaw.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity>
	where TEntity : class, IBaseEntity
	{
		private readonly InternitlawContext _dbContext;
		private DbSet<TEntity> _dbSet;
		public GenericRepository(InternitlawContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public async Task<TEntity> Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
		    await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<int> Delete(int id)
		{
			var entity = await GetById(id);
			//_dbContext.Set<TEntity>().Update(entity);
			if (entity != null)
			{
				_dbContext.Set<TEntity>().Remove(entity);
			}
			return await _dbContext.SaveChangesAsync();
		}

		public virtual IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
			//return _dbContext.Set<TEntity>().AsNoTracking().Where(x => x.Active == 1);
		}

		public async virtual Task<TEntity> GetById(int Id, string[] includes = null)
		{
			return await _dbContext.Set<TEntity>()
				 .AsNoTracking()
				 .IncludeMultiple(includes)
				 .FirstOrDefaultAsync(e => e.Id == Id);
		}
		public async Task<int> Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> Update(int id, TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			return await _dbContext.SaveChangesAsync();
		}

		public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
		{
			IQueryable<TEntity> query = _dbSet;

			if (filter != null)
				query = query.Where(filter);

			if (orderBy != null)
				query = orderBy(query);
			return query;
		}

		public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _dbSet;

			foreach (Expression<Func<TEntity, object>> include in includes)
				query = query.Include(include);

			return query.FirstOrDefault(filter);
		}
	}
}
