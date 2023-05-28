using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class SeatTypeRepository : BaseRepository<SeatType>, ISeatTypeRepository
    {
        public SeatTypeRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<SeatType>> GetAllAsync()
        {
            return await _dbSet.Include(f => f.Airplane).Include(f => f.Tickets).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<SeatType>> GetByAirplaneIdAsync(int airplaneId)
        {
            return await _dbSet.Include(f => f.Airplane).Include(f => f.Tickets).AsNoTracking().Where(f => f.AirplaneId == airplaneId).ToListAsync();
        }

        public async override Task<SeatType> GetByIdAsync(int id) => await _dbSet
            .Include(f => f.Airplane).Include(f => f.Tickets).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }
}
