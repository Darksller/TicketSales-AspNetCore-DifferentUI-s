using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TicketSalesSystem.BLL.Entities;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendEmailAsync(EmailMessage message)
        {
            try
            {
                await _emailService.SendEmailAsync(message);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to send email. Error message: {ex.Message}");
            }
        }
    }
}
