namespace TicketSalesSystem.DAL.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string DeparturePoint { get; set; } = string.Empty;
        public string ArrivalPoint { get; set; } = string.Empty;
        public List<Flight>? Flights { get; set; } = null;
    }
}
