using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class FlightStatusProfile : Profile
    {
        public FlightStatusProfile()
        {
            CreateMap<FlightStatusModel,FlightStatusDTO>().ReverseMap();
        }
    }
}
