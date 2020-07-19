using System;

namespace IhkObserver.Mail.Exceptions
{
    public class SmtpNotAuthenticatedException : SmtpException
    {
        public SmtpNotAuthenticatedException() : base()
        {

        }

        public SmtpNotAuthenticatedException(string message) : base(message)
        {

        }

        public SmtpNotAuthenticatedException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
