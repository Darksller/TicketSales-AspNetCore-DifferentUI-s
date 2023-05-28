using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public Decimal Price { get; set; }
        public bool IsConfirmed { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        public int FlightId { get; set; }
        public Flight? Flight { get; set; } = null;
        public int SeatTypeId { get; set; }
        public SeatType? SeatType { get; set; } = null;
    }
}
