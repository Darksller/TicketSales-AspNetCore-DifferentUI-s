using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class SeatType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public int Count { get; set; }
        public int AirplaneId { get; set; }
        public Airplane? Airplane { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
