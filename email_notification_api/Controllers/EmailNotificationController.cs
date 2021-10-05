using CSharpFunctionalExtensions;
using email_notification_api.Constants;
using email_notification_api.Response;
using email_notification_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace email_notification_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {
        private const string EndpointPrefix = General.apiPrefixName + "email.";

        private readonly IEmailService _emailService;
        public EmailNotificationController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string recipients)
            => ActionResponse.Success(
                HttpStatusCode.OK,
                await _emailService
                     .SendAsync(recipients)
                    .ConfigureAwait(false),
                $"{EndpointPrefix}notification");
    }
}
