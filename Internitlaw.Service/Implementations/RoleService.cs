using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.Contracts;
using Internitlaw.Service.Contracts;

namespace Internitlaw.Service.Implementations
{
	public class RoleService : IRoleService
	{
		private readonly IRoleRepository _roleRepository;
		public RoleService(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}
		public async Task<Role> Create(Role role)
		{
			return await _roleRepository.Create(role);
		}

		public async Task<int> Delete(int Id)
		{
			return await _roleRepository.Delete(Id);
		}

		public async Task<IEnumerable<Role>> GetAll()
		{
			return await _roleRepository.GetAll().ToListAsync();
		}

		public async Task<Role> GetById(int Id)
		{
			return await _roleRepository.GetById(Id);
		}

		public async Task<int> Update(Role role)
		{
			return await _roleRepository.Update(role);
		}
	}
}
