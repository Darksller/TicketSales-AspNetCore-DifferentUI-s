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
    internal class FlightStatusRepository : BaseRepository<FlightStatus>, IFlightStatusRepository
    {
        public FlightStatusRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<FlightStatus>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(f => f.Flights).ToListAsync();
        }

        public async override Task<FlightStatus> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(f => f.Flights).FirstOrDefaultAsync(a => a.Id == id);
    }
}
