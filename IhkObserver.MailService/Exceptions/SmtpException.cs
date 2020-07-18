using System;

namespace IhkObserver.MailService.Exceptions
{
    /// <summary>
    /// Abstract base exception for all smtp related exceptions.
    /// </summary>
    public abstract class SmtpException : Exception
    {
        public SmtpException() : base()
        {

        }

        public SmtpException(string message) : base(message)
        {

        }

        public SmtpException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
