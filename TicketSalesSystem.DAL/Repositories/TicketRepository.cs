using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(a => a.User).Include(a => a.Flight).Include(a => a.SeatType).ToListAsync();
        }

        public async override Task<Ticket> GetByIdAsync(int id) =>
            await _dbSet.AsNoTracking().Include(a => a.User).Include(a => a.Flight).Include(a => a.SeatType).FirstOrDefaultAsync(a => a.Id == id);
    }
}
