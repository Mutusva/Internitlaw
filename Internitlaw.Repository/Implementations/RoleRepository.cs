using System;
using System.Collections.Generic;
using System.Text;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.Contracts;
using Internitlaw.Repository.EFContext;

namespace Internitlaw.Repository.Implementations
{
	public class RoleRepository : GenericRepository<Role>, IRoleRepository
	{
		public RoleRepository(InternitlawContext dbContext) : base(dbContext)
		{
		}
	}
}
