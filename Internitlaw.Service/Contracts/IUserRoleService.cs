using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;

namespace Internitlaw.Service.Contracts
{
	public interface IUserRoleService
	{
		Task<IEnumerable<UserRole>> GetAll();
		Task<UserRole> Create(UserRole userRole);
		Task<int> Update(UserRole UserRole);
		Task<int> Delete(int Id);
		Task<UserRole> GetById(int Id);
	}
}
