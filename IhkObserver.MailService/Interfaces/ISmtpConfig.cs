using System;
using System.Collections.Generic;
using System.Text;

namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
