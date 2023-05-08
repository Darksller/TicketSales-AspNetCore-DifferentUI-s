using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeatTypeController : ControllerBase
    {
        private ISeatTypeService _seatTypeService;

        public SeatTypeController(ISeatTypeService seatTypeService)
        {
            _seatTypeService = seatTypeService;
        }

        [HttpGet]
        [Route("GetSeatTypesByAirplaneId")]
        public async Task<IEnumerable<SeatTypeDTO>> GetSeatTypesByAirplaneId(int id)
        {
            return await _seatTypeService.GetSeatTypesByAirplaneId(id);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<SeatTypeDTO> GetById(int id)
        {
            return await _seatTypeService.GetByIdAsync(id);
        }
    }
}
