using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.BLL.DTOs
{
    public class AirplaneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Speed { get; set; }
    }
}
