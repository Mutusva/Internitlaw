using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;
using Internitlaw.Repository.Contracts;
using Internitlaw.Service.Contracts;

namespace Internitlaw.Service.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IRoleRepository _roleRepository;
		public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
		}

		public async Task<User> Create(User user, ApplicationRole[] userRoles)
		{
			var roleNames = userRoles?.Select(r => r.ToString()).ToList();
			if(roleNames != null)
			{
				var rolesResults = await _roleRepository.GetAll().ToListAsync();
				var roles = rolesResults.Where(r => roleNames.Contains(r.Name));

				foreach (var role in roles)
				{
					user.UserRoles.Add(new UserRole { RoleId = role.Id });
				}
			}			

			return await _userRepository.Create(user);
		}

		public async Task<int> Delete(int Id)
		{
			return await _userRepository.Delete(Id);
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _userRepository.GetAll().ToListAsync();
		}

		public async Task<User> GetById(int Id)
		{
			return await _userRepository.GetById(Id);
		}

		public async Task<int> Update(User user)
		{
			return await _userRepository.Update(user);
		}

		public async Task<User> FindByUsername(string email)
		{
			return await _userRepository.FindByUsername(email);
		}
	}
}
