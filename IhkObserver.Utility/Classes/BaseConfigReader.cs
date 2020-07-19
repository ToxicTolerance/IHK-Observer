using IhkObserver.Utility.Exceptions;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IhkObserver.Utility.Classes
{
    public abstract class BaseConfigReader
    {
        protected async Task<string> ReadAsync(string path)
        {
            try
            {
                return await ReadBaseAsync(path);
            }
            catch (Exception)
            {
                try
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    return await ReadBaseAsync(path);
                }
                catch (Exception ex)
                {
                    throw new ConfigUnreadableException("Config could not be read!", ex);
                }
            }
        }

        private async Task<string> ReadBaseAsync(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                return await reader.ReadToEndAsync();
            }
        }

        protected string ConfigPath => "../../../../Config/";
    }
}