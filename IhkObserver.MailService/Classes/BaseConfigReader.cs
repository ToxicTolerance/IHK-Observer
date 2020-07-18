using IhkObserver.MailService.Exceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public abstract class BaseConfigReader
    {
        protected async Task<string> ReadAsync(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                using (StreamReader reader = new StreamReader(fs))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ConfigUnreadableException("Config could not be read!", ex);
            }
        }

        protected string ConfigPath => "../../../../Config/";
    }
}