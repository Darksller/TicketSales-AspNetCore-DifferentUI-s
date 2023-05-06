using System.ComponentModel.DataAnnotations;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
