using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Profiles
{
    public class FlightStatusProfile : Profile
    {
        public FlightStatusProfile()
        {
            CreateMap<FlightStatus,FlightStatusDTO>().ReverseMap();
        }
    }
}
