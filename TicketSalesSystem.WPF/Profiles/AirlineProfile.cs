using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class AirlineProfile : Profile
    {
        public AirlineProfile()
        {
            CreateMap<AirlineModel, AirlineDTO>().ReverseMap();
        }
    }
}
