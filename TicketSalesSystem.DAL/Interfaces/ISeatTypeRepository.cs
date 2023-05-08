using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.DAL.Interfaces
{
    public interface ISeatTypeRepository : IBaseRepository<SeatType>
    {
        public Task<IEnumerable<SeatType>> GetByAirplaneIdAsync(int airplaneId);
    }
}
