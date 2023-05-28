using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationContext context) : base(context)
        {
        }

        public async override Task<Route> GetByIdAsync(int id) => await _dbSet.Include(r => r.Flights).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        public override async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await _dbSet.Include(r => r.Flights).AsNoTracking().ToListAsync();
        }
    }
}
