using IhkObserver.MailService.Exceptions;
using IhkObserver.MailService.Interfaces;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class SmtpConfigReader : ISmtpConfigReader
    {
        public async Task<ISmtpConfig> ReadAsync()
        {
            string fileContents = null;
            try
            {
                using (FileStream fs = new FileStream("../../../../Config/SmtpConfig.json", FileMode.Open))
                using (StreamReader reader = new StreamReader(fs))
                {
                    fileContents = await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ConfigUnreadableException("Config could not be read!", ex);
            }

            try
            {
                return JsonSerializer.Deserialize<SmtpConfig>(fileContents);
            }
            catch (Exception ex)
            {
                throw new ConfigUnparsableException("Config could not be parsed!", ex);
            }
        }

        private class SmtpConfig : ISmtpConfig
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
    }
}