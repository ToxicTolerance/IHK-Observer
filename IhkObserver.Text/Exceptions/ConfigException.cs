using System;

namespace IhkObserver.Text.Exceptions
{
    /// <summary>
    /// Abstract base class for all config related exceptions
    /// </summary>
    public abstract class ConfigException : Exception
    {
        public ConfigException() : base()
        {

        }

        public ConfigException(string message) : base(message)
        {

        }

        public ConfigException(string message, Exception innerEx) : base(message)
        {

        }
    }
}
