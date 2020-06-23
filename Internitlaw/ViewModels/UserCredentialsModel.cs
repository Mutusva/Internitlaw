using System.ComponentModel.DataAnnotations;

namespace Internitlaw.Api.ViewModels
{
    public class UserCredentialsModel
	{
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
}
