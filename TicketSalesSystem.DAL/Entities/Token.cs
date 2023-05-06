using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
