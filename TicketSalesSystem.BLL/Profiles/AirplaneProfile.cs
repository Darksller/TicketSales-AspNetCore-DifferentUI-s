using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
    public class AirplaneProfile : Profile
    {
        public AirplaneProfile()
        {
            CreateMap<Airplane, AirplaneDTO>().ReverseMap();
        }
    }
}
