using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;

using TicketSalesSystem.MVC.Identity.Models;

namespace TicketSalesSystem.MVC.Identity.Controllers
{
	public class TicketController : Controller
	{
		private readonly ILogger<TicketController> _logger;
		private readonly ITicketService _ticketService;
		public TicketController(ILogger<TicketController> logger, ITicketService ticketService)
		{
			_logger = logger;
			_ticketService = ticketService;
		}

		public async Task<IActionResult> Index()
		{
			var res = await _ticketService.GetByUserIdAsync(8);

			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> ThankYou(TicketDTO ticket)
		{
			var res = await _ticketService.CreateAsync(ticket);

			return View();
		}

		[HttpDelete]
		public async Task<IActionResult> CancelTicket(TicketDTO ticket)
		{
			var res = await _ticketService.DeleteAsync(ticket);

			return Ok();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}