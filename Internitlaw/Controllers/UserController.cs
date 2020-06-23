using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internitlaw.Api.ViewModels;
using Internitlaw.Domain.Models;
using Internitlaw.Service.Contracts;

namespace Internitlaw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [Route("/api/Users")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAll();
          
            var managers = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(result);
            return Ok(managers);
        }
    }
}