using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Internitlaw.Domain.Models;

namespace Internitlaw.Domain.Security
{
	public class UserInfo
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string EmailAddress { get; set; }
		public string ContactNumber { get; set; }
		public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
	}
}
