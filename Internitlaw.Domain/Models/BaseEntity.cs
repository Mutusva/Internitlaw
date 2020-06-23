using System;

namespace Internitlaw.Domain.Models
{
	public class BaseEntity : IBaseEntity
	{
		public int Id { get; set; }
		public int Active { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
