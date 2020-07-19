using IhkObserver.Text.Exceptions;
using IhkObserver.Text.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IhkObserver.Text.Classes
{
    public class MailConfigReader : BaseConfigReader, IMailConfigReader
    {
        public async Task<IMailConfig> ReadAsync()
        {
            string[] json = GetSubstrings(await ReadAsync(ConfigPath + "MailConfig.json"));

            try
            {
                MailConfig mailConfig = JsonConvert.DeserializeObject<MailConfig>(json[0]);
                SmtpConfig smtpConfig = JsonConvert.DeserializeObject<SmtpConfig>(json[1]);

                smtpConfig.Mail = mailConfig.SendFrom;
                mailConfig.SmtpSetting = smtpConfig;

                return mailConfig;
            }
            catch (Exception ex)
            {
                throw new ConfigUnparsableException("MailConfig.json could not be parsed!", ex);
            }
        }

        private string[] GetSubstrings(string jsonContent)
        {
            int smtpStartIndex = jsonContent.IndexOf("\"SmtpSetting\"");
            int smtpEndIndex = jsonContent.IndexOf('}', smtpStartIndex);

            string SmtpSetting = jsonContent.Substring(smtpStartIndex + 12, smtpEndIndex - smtpStartIndex - 12) + "}";
            SmtpSetting = SmtpSetting.Remove(0, SmtpSetting.IndexOf("{")).Remove(1, SmtpSetting.IndexOf("\""));
            SmtpSetting = SmtpSetting.Remove(1, SmtpSetting.IndexOf("\""));
            SmtpSetting = SmtpSetting.Insert(1, "\"");

            string GeneralSetting = jsonContent.Substring(0, smtpStartIndex).Remove(jsonContent.LastIndexOf(',', smtpStartIndex)) + "}";
            return new string[] { GeneralSetting, SmtpSetting };
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
            public string Mail { get; set; }
            public string SenderPassword { get; set; }
        }
    }
}
