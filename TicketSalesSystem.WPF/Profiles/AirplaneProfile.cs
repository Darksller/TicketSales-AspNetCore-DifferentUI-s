using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class AirplaneProfile : Profile
    {
        public AirplaneProfile()
        {
            CreateMap<AirplaneModel, AirplaneDTO>().ReverseMap();
        }
    }
}
