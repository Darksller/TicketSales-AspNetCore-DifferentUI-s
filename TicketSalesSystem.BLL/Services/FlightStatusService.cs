using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class FlightStatusService : IFlightStatusService
    {
        public Task<FlightStatusDTO> CreateAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<FlightStatusDTO> DeleteAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FlightStatusDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FlightStatusDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightStatusDTO> UpdateAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
