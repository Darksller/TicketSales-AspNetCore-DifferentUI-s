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
    internal class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        public TokenRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Token>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(a => a.User).ToListAsync();
        }

        public override async Task<Token> GetByIdAsync(int id) => await _dbSet.AsNoTracking().Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Token> GetByTokenAsync(string token) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.RefreshToken == token);
        public async Task<Token?> GetByUserIdAsync(int userId) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.UserId == userId);
    }
}
