using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
    public class AirlineProfile : Profile
    {
        public AirlineProfile()
        {
            CreateMap<Airline, AirlineDTO>().ReverseMap();
        }
    }
}
