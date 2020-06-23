using System;
using Internitlaw.Domain.Models;

namespace Internitlaw.Domain.Security
{
    public class AccessToken : JsonWebToken
	{
        public RefreshToken RefreshToken { get; private set; }
        public User UserInfo { get; set; }

        public AccessToken(string token, long expiration, RefreshToken refreshToken, User user) : base(token, expiration)
        {
            UserInfo = user;
            RefreshToken = refreshToken ?? throw new ArgumentException("Specify a valid refresh token.");
        }
    }
}
