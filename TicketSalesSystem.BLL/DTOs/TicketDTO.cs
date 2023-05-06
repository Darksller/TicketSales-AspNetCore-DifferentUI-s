using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.BLL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public Decimal Price { get; set; }
    }
}
 