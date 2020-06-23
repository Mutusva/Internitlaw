using System.Threading.Tasks;
using Internitlaw.Service.Contracts;
using Internitlaw.Service.Security;
using Internitlaw.Service.Security.Responses;

namespace Internitlaw.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
	{
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher, ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            var user = await _userService.FindByUsername(email);

            if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string email)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }

            var user = await _userService.FindByUsername(email);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            var accessToken = _tokenHandler.CreateAccessToken(user);
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}
