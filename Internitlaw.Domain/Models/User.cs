using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Internitlaw.Domain.Models
{
	public class User : BaseEntity
	{
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public string EmailAddress { get; set; }
		public string ContactNumber { get; set; }
		public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
	}
}
