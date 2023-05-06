using AutoMapper;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, RefreshTokenDTO>().ReverseMap();
        }
    }
}
