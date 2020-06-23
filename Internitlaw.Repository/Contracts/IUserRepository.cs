using System.Collections.Generic;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;

namespace Internitlaw.Repository.Contracts
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User> FindByUsername(string email);
	}
}
