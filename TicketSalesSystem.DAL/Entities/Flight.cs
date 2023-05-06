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
        public FlightStatus? FlightStatus { get; set; }
        public int RouteId { get; set; }
        public Route? Route { get; set; }
        public int AirplaneId { get; set; }
        public Airplane? Airplane { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = new();
    }
}
