using System.ComponentModel.DataAnnotations;

namespace Internitlaw.Api.ViewModels
{
	public class UserSignOnModel
	{
		[Required]
		[MaxLength(50)]
		public string Firstname { get; set; }

		[Required]
		[MaxLength(50)]
		public string Surname { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[MaxLength(50)]
		public string EmailAddress { get; set; }

		[Required]
		[MaxLength(50)]
		public string Password { get; set; }

		[Required]
		[MaxLength(20)]
		public string ContactNumber { get; set; }

	}
}
