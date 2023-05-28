using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightStatusController : ControllerBase
    {
        private readonly IFlightStatusService _flightStatusService;

        public FlightStatusController(IFlightStatusService flightStatusService)
        {
            _flightStatusService = flightStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightStatusDTO>>> GetAll()
        {
            var res = await _flightStatusService.GetAllAsync();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FlightStatusDTO>> GetById(int id)
        {
            var res = await _flightStatusService.GetByIdAsync(id);

            return Ok(res);
        }
    }
}
