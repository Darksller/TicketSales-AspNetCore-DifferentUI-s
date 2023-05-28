using Microsoft.EntityFrameworkCore;
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
            return await _dbSet.Include(a => a.User).AsNoTracking().ToListAsync();
        }

        public override async Task<Token> GetByIdAsync(int id) => await _dbSet.Include(a => a.User).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        public async Task<Token> GetByTokenAsync(string token) => await _dbSet.Include(a => a.User).AsNoTracking().FirstOrDefaultAsync(t => t.RefreshToken == token);
        public async Task<Token?> GetByUserIdAsync(int userId) => await _dbSet.Include(a => a.User).AsNoTracking().FirstOrDefaultAsync(t => t.UserId == userId);
    }
}
