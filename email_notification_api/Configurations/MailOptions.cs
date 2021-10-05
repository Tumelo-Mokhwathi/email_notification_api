using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_notification_api.Configurations
{
    public class MailOptions
    {
        public string FromAddress { get; set; }
        public string Recipients { get; set; }
        public string Server { get; set; }
    }
}
