using System.Threading.Tasks;
using Internitlaw.Domain.Models;

namespace Internitlaw.Repository.Contracts
{
	public interface IUserRoleRepository : IGenericRepository<UserRole>
	{
		Task<UserRole> FindByUserId(int userId);
	}
}
