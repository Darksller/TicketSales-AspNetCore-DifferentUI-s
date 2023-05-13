using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightStatusController : ControllerBase
    {
        private readonly IFlightStatusService _flightStatusService;

        public FlightStatusController(IFlightStatusService flightStatusService)
        {
            _flightStatusService = flightStatusService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IEnumerable<FlightStatusDTO>> GetAll()
        {
            return await _flightStatusService.GetAllAsync();
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<FlightStatusDTO> GetById(int id)
        {
            return await _flightStatusService.GetByIdAsync(id);
        }
    }
}
