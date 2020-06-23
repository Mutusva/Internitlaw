using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.Contracts;
using Internitlaw.Repository.EFContext;

namespace Internitlaw.Repository.Implementations
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(InternitlawContext dbContext) : base(dbContext)
		{
		}

		public async Task<User> FindByUsername(string email)
		{
			return await Query(x => x.EmailAddress == email).Include(x => x.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync();
		}
	}
}
