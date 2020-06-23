
using Internitlaw.Domain.Models;
using Internitlaw.Domain.Security;

namespace Internitlaw.Api.ViewModels
{
	public class TokenResponseModel
	{
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
