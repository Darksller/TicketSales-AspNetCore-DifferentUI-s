using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        public string Passport { get; set; } = String.Empty;
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public Token? Token { get; set; }
        public string Phone { get; set; } = string.Empty;
        public List<Ticket> Tickets { get; set; } = new();
    }
}
