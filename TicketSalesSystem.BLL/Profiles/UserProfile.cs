using AutoMapper;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDTO>()
				.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
				.ReverseMap();
			CreateMap<User, ResponseUserDTO>().ReverseMap();
			CreateMap<User, RequestUserDTO>().ReverseMap();
		}
	}
}
