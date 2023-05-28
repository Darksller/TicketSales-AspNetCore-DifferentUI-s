using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketModel, TicketDTO>().ReverseMap();
        }
    }
}
