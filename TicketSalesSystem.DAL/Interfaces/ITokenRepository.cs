using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.DAL.Interfaces
{
    public interface ITokenRepository : IBaseRepository<Token>
    {
        Task<Token> GetByTokenAsync(string token);
        public Task<Token?> GetByUserIdAsync(int userId);
    }
}
