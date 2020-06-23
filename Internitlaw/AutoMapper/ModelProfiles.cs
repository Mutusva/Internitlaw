using AutoMapper;
using System;
using Internitlaw.Api.ViewModels;
using Internitlaw.Domain.Models;
using Internitlaw.Domain.Security;

namespace Internitlaw.Api.AutoMapper
{
	public class ModelProfiles : Profile
	{
		public ModelProfiles()
		{
			CreateMap<UserSignOnModel, User>()
				.ForMember(opt => opt.UserRoles, opt => opt.Ignore());

			CreateMap<AccessToken, TokenResponseModel>()
				.ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
				.ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
				.ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));

			CreateMap<User, UserViewModel>();

			CreateMap<User, UserInfo>();
		}
	}
}
