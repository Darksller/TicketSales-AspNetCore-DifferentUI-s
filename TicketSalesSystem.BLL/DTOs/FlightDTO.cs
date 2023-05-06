using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.BLL.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
        public int AirlineId { get; set; }
        public int RouteId { get; set; }
        public Decimal Price { get; set; }
    }
}
