namespace TicketSalesSystem.BLL.DTOs
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string DeparturePoint { get; set; } = string.Empty;
        public string ArrivalPoint { get; set; } = string.Empty;
        public List<FlightDTO>? Flights { get; set; } = null;
    }
}
