using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbSet.Include(f => f.Users).AsNoTracking().ToListAsync();
        }

        public async override Task<Role> GetByIdAsync(int id)
            => await _dbSet.Include(f => f.Users).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Role> GetByNameAsync(string name)
            => await _dbSet.Include(f => f.Users).AsNoTracking().FirstOrDefaultAsync(a => a.Name == name);
    }
}
