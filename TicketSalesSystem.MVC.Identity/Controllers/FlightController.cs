using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.MVC.Identity.Models;

namespace TicketSalesSystem.MVC.Identity.Controllers
{
	public class FlightController : Controller
	{
		private readonly ILogger<FlightController> _logger;
		private readonly IFlightService _flightService;
		public FlightController(ILogger<FlightController> logger, IFlightService flightService)
		{
			_logger = logger;
			_flightService = flightService;
		}

		public async Task<IActionResult> Index(string departure, string arrival, DateTime date)
		{
			var res = await _flightService.GetSearchedFlights(departure, arrival, date);
			return View(res);
		}

		public async Task<IActionResult> FlightEditAsync()
		{
			var res = await _flightService.GetAllAsync();

			return View(res);
		}

		[HttpPut]
		public async Task<IActionResult> Update(FlightDTO flight)
		{
			var res = await _flightService.UpdateAsync(flight);

			return Ok();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}