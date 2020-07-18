﻿using System;

namespace IhkObserver.MailService.Exceptions
{
    public class SmtpNotConnectedException : SmtpException
    {
        public SmtpNotConnectedException() : base()
        {

        }

        public SmtpNotConnectedException(string message) : base(message)
        {

        }

        public SmtpNotConnectedException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
