using Microsoft.Extensions.DependencyInjection;
using Internitlaw.Repository.Contracts;
using Internitlaw.Repository.Implementations;
using Internitlaw.Service.Contracts;
using Internitlaw.Service.Implementations;
using Internitlaw.Service.Security;

namespace Internitlaw.Api.Extensions
{
	public static class DIServiceExtension
	{
		public static void AddDIServices(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IRoleService, RoleService>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IPasswordHasher, PasswordHasher>();
			services.AddTransient<ITokenHandler, TokenHandler>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			
		}
	}
}
