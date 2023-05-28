using Microsoft.EntityFrameworkCore;
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
            return await _dbSet.Include(f => f.Flights).AsNoTracking().ToListAsync();
        }

        public async override Task<FlightStatus> GetByIdAsync(int id) => await _dbSet.Include(f => f.Flights).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }
}
