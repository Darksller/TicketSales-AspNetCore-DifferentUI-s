using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.BLL.Profiles
{
    public class SeatTypeProfile:Profile
    {
        public SeatTypeProfile()
        {
            CreateMap<SeatTypeModel, SeatTypeDTO>().ReverseMap();
        }
    }
}
