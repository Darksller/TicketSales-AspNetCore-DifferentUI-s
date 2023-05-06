using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
