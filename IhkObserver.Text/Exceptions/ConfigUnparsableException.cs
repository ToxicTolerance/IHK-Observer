using System;

namespace IhkObserver.Text.Exceptions
{
    public class ConfigUnparsableException : ConfigException
    {
        public ConfigUnparsableException() : base()
        {

        }

        public ConfigUnparsableException(string message) : base(message)
        {

        }

        public ConfigUnparsableException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
