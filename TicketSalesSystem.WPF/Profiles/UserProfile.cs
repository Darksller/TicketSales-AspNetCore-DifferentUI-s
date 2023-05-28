using AutoMapper;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserModel, UserDTO>().ReverseMap();
		}
	}
}
