using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class AirplaneRepository : BaseRepository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Airplane>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.SeatTypes).Include(a => a.Flights).AsNoTracking().ToListAsync();
        }

        public async override Task<Airplane> GetByIdAsync(int id) =>
            await _dbSet.Include(a => a.SeatTypes).Include(a => a.Flights)
            .AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }
}
