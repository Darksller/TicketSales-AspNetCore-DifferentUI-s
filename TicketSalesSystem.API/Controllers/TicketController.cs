using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<ActionResult<TicketDTO>> Create([FromBody] TicketDTO ticket)
        {
            var res = await _ticketService.CreateAsync(ticket);

            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<TicketDTO>> Update([FromBody] TicketDTO ticket)
        {
            var res = await _ticketService.UpdateAsync(ticket);

            return Ok(res);
        }

        [HttpGet]
        [Route("getUnconfirmed")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetUnconfirmed()
        {
            var res = await _ticketService.GetUnconfirmedAsync();

            return Ok(res);
        }
    }
}
