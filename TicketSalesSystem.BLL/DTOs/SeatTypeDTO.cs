namespace TicketSalesSystem.BLL.DTOs
{
    public class SeatTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
    }
}
