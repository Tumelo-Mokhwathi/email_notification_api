using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace email_notification_api.Response
{
    public static class ActionResponse
    {
        public static IActionResult Success(HttpStatusCode code, object result, string source)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new JsonResult(new { code, result, source });
        }

        public static IActionResult Error(HttpStatusCode code, string message, string source)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new JsonResult(new ErrorResponse(code, message, source))
            {
                StatusCode = (int)code
            };
        }
    }
}
