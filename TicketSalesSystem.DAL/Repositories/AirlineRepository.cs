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
    internal class AirlineRepository : BaseRepository<Airline>, IAirlineRepository
    {
        public AirlineRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Airline>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().Include(a => a.Flights).ToListAsync();
        }

        public async override Task<Airline> GetByIdAsync(int id) =>
            await _dbSet.AsNoTracking().Include(a => a.Flights).FirstOrDefaultAsync(a => a.Id == id);
    }
}
