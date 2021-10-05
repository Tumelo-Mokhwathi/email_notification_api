using CSharpFunctionalExtensions;
using email_notification_api.Configurations;
using email_notification_api.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace email_notification_api.Services
{
    public class EmailService : IEmailService
    {
        private readonly FtpOptions _ftpOptions;
        private readonly MailOptions _mailOptions;
        public EmailService(IOptions<FtpOptions> ftpOptions, IOptions<MailOptions> mailOptions)
        {
            _ftpOptions = ftpOptions.Value;
            _mailOptions = mailOptions.Value;
        }
        public async Task<bool> SendAsync(string recipients)
        {
            bool isEmailSend = false;

            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\EmailTemplate.html";
            StreamReader stream = new StreamReader(FilePath);
            string MailText = stream.ReadToEnd();
            stream.Close();

            using var smtp = new SmtpClient();

            var message = new MailMessage(_mailOptions.FromAddress, recipients)
            {
                Subject = "Email Notification",
                Body = MailText,
                IsBodyHtml = true
            };

            using (var client = new SmtpClient(_mailOptions.Server, _ftpOptions.Port))
            {
                client.Credentials = new NetworkCredential(_ftpOptions.User, _ftpOptions.Password);
                client.EnableSsl = true;

                await client.SendMailAsync(message);
                isEmailSend = true;
            }

            return isEmailSend;
        }
    }
}
