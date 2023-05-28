using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.API.Entities;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> GetFlights([FromBody] FlightSearchCriteria criteria)
        {
            var res = await _flightService.GetSearchedFlights(criteria.DeparturePoint, criteria.ArrivalPoint, criteria.DepartureTime);

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FlightDTO>> GetFlightById(int id)
        {
            var res = await _flightService.GetByIdAsync(id);

            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> GetAll()
        {
            var res = await _flightService.GetAllAsync();

            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<FlightDTO>> Update([FromBody] FlightDTO flightDTO)
        {
            var res = await _flightService.UpdateAsync(flightDTO);

            return Ok(res);
        }
    }
}
