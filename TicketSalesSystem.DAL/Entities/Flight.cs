using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.DAL.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Decimal Price { get; set; }
        public int FlightStatusId { get; set; }
        public FlightStatus? FlightStatus { get; set; } = null;
        public int RouteId { get; set; }
        public Route? Route { get; set; } = null;
        public int AirplaneId { get; set; }
        public Airplane? Airplane { get; set; } = null;
        public List<Ticket>? Tickets { get; set; } = null;
        public int AirlineId { get; set; }
        public Airline? Airline { get; set; } = null;
    }
}
