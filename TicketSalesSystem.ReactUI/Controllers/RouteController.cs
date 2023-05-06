using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        [Route("GetRouteById")]
        public async Task<RouteDTO> GetRouteByID(int id)
        {   
            return await _routeService.GetByIdAsync(id);
        }
    }
}
