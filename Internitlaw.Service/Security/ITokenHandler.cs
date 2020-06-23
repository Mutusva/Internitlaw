using Internitlaw.Domain.Models;
using Internitlaw.Domain.Security;

namespace Internitlaw.Service.Security
{
	public interface ITokenHandler
	{
		AccessToken CreateAccessToken(User user);
		RefreshToken TakeRefreshToken(string token);
		void RevokeRefreshToken(string token);
	}
}
