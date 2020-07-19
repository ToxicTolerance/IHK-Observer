using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface IMailSender
    {
        public Task SendResultsAsync(object sender, EventArgs e, IEnumerable<SubjectMarks> results);
    }
}
