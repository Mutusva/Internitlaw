using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;

namespace Internitlaw.Service.Contracts
{
	public interface IRoleService
	{
		Task<IEnumerable<Role>> GetAll();
		Task<Role> Create(Role role);
		Task<int> Update(Role role);
		Task<int> Delete(int Id);
		Task<Role> GetById(int Id);
	}
}
