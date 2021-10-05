using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_notification_api.Configurations
{
    public class FtpOptions
    {
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
