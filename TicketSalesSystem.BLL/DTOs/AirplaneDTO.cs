
namespace TicketSalesSystem.BLL.DTOs
{
    public class AirplaneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Speed { get; set; }
        public List<SeatTypeDTO>? SeatTypes { get; set; } = null;
    }
}
