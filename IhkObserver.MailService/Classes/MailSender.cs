using IhkObserver.MailService.Interfaces;
using IhkObserver.Observer.Classes;
using IhkObserver.Utility.Classes;
using IhkObserver.Utility.Interfaces;
using MimeKit;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class MailSender : IMailSender
    {
        public async Task SendResultsAsync(IEnumerable<SubjectMarks> results)
        {
            IMailConfig config = await new MailConfigReader().ReadAsync();

            ISmtpClientGetter smtpGetter = new SmtpClientGetter();
            await smtpGetter.InitializeSmtpClientAsync(config.SmtpSetting);

            smtpGetter.Smtp.Send(CreateMimeMessage(config, results));
        }

        private MimeMessage CreateMimeMessage(IMailConfig config, IEnumerable<SubjectMarks> results)
        {
            StringBuilder body = new StringBuilder("Dies sind deine Resultate: \n\n");
            foreach (SubjectMarks subject in results)
            {
                body.Append($"{subject.Subject} mit {subject.Points} Punkten, Note {subject.Mark}. \n");
            }
            body.Append("Gratulation!");

            return new MimeMessage(
                new List<InternetAddress> { MailboxAddress.Parse(config.SendFrom) },
                new List<InternetAddress> { MailboxAddress.Parse(config.SendTo) },
                config.Subject,
                new TextPart() { Text = body.ToString() });
        }
    }
}