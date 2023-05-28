using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatTypeController : ControllerBase
    {
        private ISeatTypeService _seatTypeService;

        public SeatTypeController(ISeatTypeService seatTypeService)
        {
            _seatTypeService = seatTypeService;
        }

        [HttpGet]
        [Route("getByAirplaneId/{id}")]
        public async Task<ActionResult<IEnumerable<SeatTypeDTO>>> GetSeatTypesByAirplaneId(int id)
        {
            var res = await _seatTypeService.GetSeatTypesByAirplaneId(id);

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SeatTypeDTO>> GetById(int id)
        {
            var res = await _seatTypeService.GetByIdAsync(id);

            return Ok(res);
        }
    }
}
