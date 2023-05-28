using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class AirlineRepository : BaseRepository<Airline>, IAirlineRepository
    {
        public AirlineRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Airline>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.Flights).AsNoTracking().ToListAsync();
        }

        public async override Task<Airline> GetByIdAsync(int id) =>
            await _dbSet.Include(a => a.Flights).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }
}
