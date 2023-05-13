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
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.Role).Include(a => a.Token)
                .Include(a => a.Tickets).AsNoTracking().ToListAsync();
        }

        public async override Task<User> GetByIdAsync(int id) =>
            await _dbSet.Include(a => a.Role).Include(a => a.Token)
                .Include(a => a.Tickets).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<User?> GetByEmailAsync(string email) =>
            await _dbSet.Include(a => a.Role).Include(a => a.Token)
                .Include(a => a.Tickets).AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }
}
