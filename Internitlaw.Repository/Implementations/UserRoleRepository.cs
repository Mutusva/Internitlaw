using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.Contracts;
using Internitlaw.Repository.EFContext;

namespace Internitlaw.Repository.Implementations
{
	public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
	{
		public UserRoleRepository(InternitlawContext dbContext) : base(dbContext)
		{
			
		}

		public async Task<UserRole> FindByUserId(int userId)
		{
			return await Query(x => x.UserId == userId).Include(x => x.Role).FirstOrDefaultAsync();
		}
	}
}
