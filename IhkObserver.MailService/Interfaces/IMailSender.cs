using IhkObserver.Observer.Classes;
using System.Collections.Generic;

namespace IhkObserver.MailService.Interfaces
{
    public interface IMailSender
    {
        public void SendResults(string recipientEmail, IEnumerable<SubjectMarks> results);
    }
}
