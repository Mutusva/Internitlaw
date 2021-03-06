﻿using Internitlaw.Domain.Models;
using Internitlaw.Service.Security.Responses;

namespace Internitlaw.Service.Security
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; private set; }

        public CreateUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
    }
}
