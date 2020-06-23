using System;
using System.Collections.Generic;
using System.Text;
using Internitlaw.Domain.Models;
using Internitlaw.Domain.Security;

namespace Internitlaw.Service.Security.Responses
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }
        public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
        {
            Token = token;
        }
    }
}
