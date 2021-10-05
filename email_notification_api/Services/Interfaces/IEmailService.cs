using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_notification_api.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string recipients);
    }
}
