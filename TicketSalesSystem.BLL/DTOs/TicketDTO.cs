namespace TicketSalesSystem.BLL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public Decimal Price { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public int SeatTypeId { get; set; }
        public bool IsConfirmed { get; set; }
        public FlightDTO? Flight { get; set; } = null;
    }
}
