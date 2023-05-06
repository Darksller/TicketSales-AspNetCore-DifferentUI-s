using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.DAL.Repositories
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public abstract Task<T> GetByIdAsync(int id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public async Task CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}


