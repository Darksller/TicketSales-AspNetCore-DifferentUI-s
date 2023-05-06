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
    internal class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(f => f.FlightStatus).Include(a => a.Route).Include(f => f.Airplane).Include(f => f.Tickets).ToListAsync();
        }

        public async override Task<Flight> GetByIdAsync(int id) =>
            await _dbSet.AsNoTracking().Include(f => f.FlightStatus).Include(a => a.Route).Include(f => f.Airplane).Include(f => f.Tickets).FirstOrDefaultAsync(a => a.Id == id);
    }
}
