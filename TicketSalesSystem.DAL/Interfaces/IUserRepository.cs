﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User?> GetByEmailAsync(string email);
    }
}
