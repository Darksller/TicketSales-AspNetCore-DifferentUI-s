using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return await _dbSet.Include(a => a.User).Include(a => a.Flight)
                .Include(a => a.SeatType).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByFlightIdAsync(int flightId)
        {
            return await _dbSet.Include(a => a.User)
                .Include(a => a.Flight).Include(a => a.SeatType).AsNoTracking().Where(a => a.FlightId == flightId).ToListAsync();
        }

        public async override Task<Ticket> GetByIdAsync(int id) =>
            await _dbSet.Include(a => a.User).Include(a => a.Flight)
            .Include(a => a.SeatType).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);


    }
}
