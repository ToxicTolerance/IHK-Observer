using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IhkObserver.Mail.Interfaces
{
    public interface IMailSender
    {
        Task SendResultsAsync(object sender, EventArgs e, IEnumerable<SubjectMarks> results);
    }
}
