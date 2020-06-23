using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Internitlaw.Api.ViewModels;
using Internitlaw.Domain.Models;
using Internitlaw.Domain.Security;
using Internitlaw.Service.Contracts;
using Internitlaw.Service.Security;

namespace Internitlaw.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IMapper mapper, IAuthenticationService authenticationService, IUserService userService, IPasswordHasher passwordHasher)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        [Route("/api/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsModel userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.EmailAddress, userCredentials.Password);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessTokenResource = _mapper.Map<AccessToken, TokenResponseModel>(response.Token);
            return Ok(accessTokenResource);
        }

        [Route("/api/SignOn")]
        [HttpPost]
        public async Task<IActionResult> SignOnAsync([FromBody] UserSignOnModel userSignOnModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userExist = await _userService.FindByUsername(userSignOnModel.EmailAddress);
            if(userExist!= null)
            {
                return BadRequest("User with same clock number exists");
            }

            var hashedPassword = _passwordHasher.HashPassword(userSignOnModel.Password);
            userSignOnModel.Password = hashedPassword;
            
            var usermap = _mapper.Map<UserSignOnModel, User>(userSignOnModel);
            var response = await _userService.Create(usermap, null);
            if (response==null)
            {
                return BadRequest("Failed to create user object");
            }           
            return Ok(userSignOnModel);
        }

        /*
        [Route("/api/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }

        [Route("/api/token/revoke")]
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
        */
    }
}