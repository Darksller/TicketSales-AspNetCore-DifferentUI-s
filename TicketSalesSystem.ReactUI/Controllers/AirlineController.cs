using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private IAirlineService _airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpGet]
        [Route("GetAirlineById")]
        public async Task<AirlineDTO> GetAirlineById(int id)
        {
            return await _airlineService.GetByIdAsync(id);
        }
    }
}
