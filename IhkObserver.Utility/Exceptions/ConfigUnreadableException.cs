using System;

namespace IhkObserver.Utility.Exceptions
{
    public class ConfigUnreadableException : ConfigException
    {
        public ConfigUnreadableException() : base()
        {

        }

        public ConfigUnreadableException(string message) : base(message)
        {

        }

        public ConfigUnreadableException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
