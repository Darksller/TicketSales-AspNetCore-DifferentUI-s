namespace TicketSalesSystem.BLL.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
        public AirplaneDTO? Airplane { get; set; } = null;
        public int FlightStatusId { get; set; }
        public FlightStatusDTO? FlightStatus { get; set; } = null;
        public int AirlineId { get; set; }
        public AirlineDTO? Airline { get; set; } = null;
        public int RouteId { get; set; }
        public RouteDTO? Route { get; set; } = null;
        public Decimal Price { get; set; }
    }
}
