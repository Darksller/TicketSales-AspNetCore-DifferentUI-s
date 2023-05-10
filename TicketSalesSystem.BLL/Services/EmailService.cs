using System.Net.Mail;
using System.Net;
using TicketSalesSystem.BLL.Entities;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            var email = new MailMessage
            {
                From = new MailAddress("rullesexpre@gmail.com"),
                Subject = message.Subject,
                Body = message.Text
            };

            email.To.Add(new MailAddress(message.To));

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("rullesexpre@gmail.com", "qxmhwrbqvlakfrxk"),
                EnableSsl = true
            };
            //ncii vvnd tzbq vvhr
            await smtpClient.SendMailAsync(email);

        }
    }
}
