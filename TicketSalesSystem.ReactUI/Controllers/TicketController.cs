using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        [Route("buyticket")]
        public async Task BuyTicket(TicketDTO ticket)
        {
            await _ticketService.CreateAsync(ticket);
        }
        [HttpPut]
        [Route("update")]
        public async Task Update(TicketDTO ticket)
        {
            await _ticketService.UpdateAsync(ticket);
        }

        [HttpGet]
        [Route("getunconfirmed")]
        public async Task<IEnumerable<TicketDTO>> GetUnconfirmed()
        {
            return await _ticketService.GetUnconfirmedAsync();
        }
    }
}
