using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Internitlaw.Repository.Extensions
{
	public static class EFEntityInclude
	{
		public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, string[] includes)
		where T : class
		{
			if (includes != null)
			{
				query = includes.Aggregate(query,(current, include) => current.Include(include));
			}

			return query;
		}
	}
}
