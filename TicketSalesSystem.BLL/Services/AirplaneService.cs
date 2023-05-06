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
    internal class AirplaneService : IAirplaneService
    {
        public Task<AirplaneDTO> CreateAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<AirplaneDTO> DeleteAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AirplaneDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AirplaneDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AirplaneDTO> UpdateAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
