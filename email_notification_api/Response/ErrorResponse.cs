using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace email_notification_api.Response
{
    public class ErrorResponse
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }
        public string source { get; set; }

        public ErrorResponse(HttpStatusCode Code, string Message, string Source)
        {
            code = Code;
            message = Message;
            source = Source;
        }
    }
}
