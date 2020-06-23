using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Domain.Models;

namespace Internitlaw.Service.Contracts
{
	public interface IUserService 
	{
		Task<IEnumerable<User>> GetAll();
		Task<User> Create(User user, ApplicationRole[] userRoles);
		Task<int> Update(User user);
		Task<int> Delete(int Id);
		Task<User> GetById(int Id);
		/// <summary>
		/// Find a user by email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		Task<User> FindByUsername(string email);

	}
}
