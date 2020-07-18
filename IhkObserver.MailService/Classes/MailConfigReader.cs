using IhkObserver.MailService.Exceptions;
using IhkObserver.MailService.Interfaces;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class MailConfigReader : BaseConfigReader, IMailConfigReader
    {
        public async Task<IMailConfig> ReadAsync()
        {
            (string mail, string smtp) json = GetSubstrings(await ReadAsync(ConfigPath + "MailConfig.json"));

            try
            {
                MailConfig mailConfig = JsonSerializer.Deserialize<MailConfig>(json.mail);
                mailConfig.SmtpSetting = JsonSerializer.Deserialize<SmtpConfig>(json.smtp);

                return mailConfig;
            }
            catch (Exception ex)
            {
                throw new ConfigUnparsableException("Config could not be parsed!", ex);
            }
        }

        private (string mail, string smtp) GetSubstrings(string jsonContent)
        {
            int smtpStartIndex = jsonContent.IndexOf("\"SmtpSetting\"");
            int smtpEndIndex = jsonContent.IndexOf('}', smtpStartIndex);

            string SmtpSetting = jsonContent.Substring(smtpStartIndex + 12, smtpEndIndex - smtpStartIndex - 12) + "}";
            SmtpSetting = SmtpSetting.Remove(0, SmtpSetting.IndexOf("{")).Remove(1, SmtpSetting.IndexOf("\""));
            SmtpSetting = SmtpSetting.Remove(1, SmtpSetting.IndexOf("\""));
            SmtpSetting = SmtpSetting.Insert(1, "\"");

            string GeneralSetting = jsonContent.Substring(0, smtpStartIndex).Remove(jsonContent.LastIndexOf(',', smtpStartIndex)) + "}";
            return (GeneralSetting, SmtpSetting);
        }

        private class MailConfig : IMailConfig
        {
            public string SendTo { get; set; }
            public string SendFrom { get; set; }
            public string Subject { get; set; }
            public bool IncludeHtml { get; set; }
            public ISmtpConfig SmtpSetting { get; set; }
        }

        private class SmtpConfig : ISmtpConfig
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string SenderPassword { get; set; }
        }
    }
}
