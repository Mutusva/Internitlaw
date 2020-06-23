using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Internitlaw.Service.Security.Responses;

namespace Internitlaw.Service.Security
{
	public interface IAuthenticationService
	{
		Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
		Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
		void RevokeRefreshToken(string refreshToken);
	}
}
