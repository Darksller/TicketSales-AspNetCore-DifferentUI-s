using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.DTOs;

namespace TicketSalesSystem.BLL.Interfaces
{
    public interface IFlightService : IBaseService<FlightDTO>
    {
        Task<IEnumerable<FlightDTO>> GetSearchedFlights(string depPoint, string arrPoint, DateTime depTime);
    }
}
