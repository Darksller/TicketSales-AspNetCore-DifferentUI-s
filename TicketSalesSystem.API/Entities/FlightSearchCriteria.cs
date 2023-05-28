namespace TicketSalesSystem.API.Entities
{
    public class FlightSearchCriteria
    {
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
