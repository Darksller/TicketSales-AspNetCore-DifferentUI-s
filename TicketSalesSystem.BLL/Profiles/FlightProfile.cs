using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDTO>().ReverseMap();
        }
    }
}
