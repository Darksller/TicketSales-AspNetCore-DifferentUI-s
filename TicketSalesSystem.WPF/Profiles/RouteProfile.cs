using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<RouteModel, RouteDTO>().ReverseMap();
        }
    }
}
