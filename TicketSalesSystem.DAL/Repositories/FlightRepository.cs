using Microsoft.EntityFrameworkCore;
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
            return await _dbSet
                .Include(f => f.FlightStatus)
                .Include(a => a.Route)
                .Include(f => f.Airplane)
                    .ThenInclude(a => a.SeatTypes)
                .Include(f => f.Tickets)
                .Include(f => f.Airline)
                .AsNoTracking()
                .ToListAsync();
        }

        public async override Task<Flight> GetByIdAsync(int id) =>
            await _dbSet
            .Include(f => f.FlightStatus)
            .Include(a => a.Route)
            .Include(f => f.Airplane)
                .ThenInclude(a => a.SeatTypes)
            .Include(f => f.Tickets)
            .Include(f => f.Airline)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
