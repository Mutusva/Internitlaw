namespace Internitlaw.Domain.Models
{
	public class UserRole : BaseEntity
	{
		public int UserId { get; set; }
		public Role Role { get; set; }
		public int RoleId { get; set; }

	}	
}
