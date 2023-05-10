using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        [Route("GetFlights")]
        public async Task<IEnumerable<FlightDTO>> GetFlights(string depPoint, string arrPoint, DateTime depTime)
        {
            return await _flightService.GetSearchedFlights(depPoint, arrPoint, depTime);
        }

        [HttpGet]
        [Route("GetFlightById")]
        public async Task<FlightDTO> GetFlightById(int id)
        {
            return await _flightService.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IEnumerable<FlightDTO>> GetAll()
        {
            return await _flightService.GetAllAsync();
        }
    }
}
