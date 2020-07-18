using IhkObserver.MailService.Interfaces;
using IhkObserver.Observer.Classes;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class MailSender : IMailSender
    {
        public async Task SendResultsAsync(IEnumerable<SubjectMarks> results)
        {
            // TODO (MG): Rework this.
            ISmtpClientGetter smtpGetter = null;
            //ISmtpClientGetter smtpGetter = new SmtpClientGetter();
            await smtpGetter.InitializeSmtpClientAsync();

            smtpGetter.Smtp.Send(CreateMimeMessage(results));
            throw new NotImplementedException();
        }

        private MimeMessage CreateMimeMessage(IEnumerable<SubjectMarks> results)
        {
            MimeMessage message = new MimeMessage();


            throw new NotImplementedException();
        }

        private async Task<IMailConfig> GetMailConfig()
        {
            return await new MailConfigReader().ReadAsync();
        }
    }
}
