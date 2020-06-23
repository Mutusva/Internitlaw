using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Internitlaw.Domain.Models
{
	public class Role : BaseEntity
	{
		[Required]
		[StringLength(50)]
		public string Name {get; set;}
	    public string Description {get; set; }
		//public ICollection<UserRole> UsersRole { get; set; } = new Collection<UserRole>();
	}  
}
