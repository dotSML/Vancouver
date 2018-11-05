using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace Vancouver.Services
{
    public class EmailService : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = /*_configuration["Email:Email"],*/ "vancouver@sml.ee",
                    Password = /*_configuration["Email:Password"]*/ "CheapFlights123"
                };

                client.Credentials = credential;
                client.Host = /*_configuration["Email:Host"];*/ "smtp.zone.ee";
                client.Port = /*int.Parse(_configuration["Email:Port"]*/ 587;
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(/*_configuration["Email:Email"]*/ "vancouver@sml.ee");
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    //client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}
