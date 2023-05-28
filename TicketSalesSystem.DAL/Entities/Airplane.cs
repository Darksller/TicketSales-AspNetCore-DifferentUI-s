using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Speed { get; set; }
        public List<SeatType>? SeatTypes { get; set; } = null;
        public List<Flight>? Flights { get; set; } = null;
    }
}
