using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.DTOs;

namespace TicketSalesSystem.BLL.Interfaces
{
    public interface ITicketService : IBaseService<TicketDTO>
    {
        public Task<IEnumerable<TicketDTO>> GetUnconfirmedAsync();
        Task<IEnumerable<TicketDTO>> GetByUserIdAsync(int userId);
    }
}
