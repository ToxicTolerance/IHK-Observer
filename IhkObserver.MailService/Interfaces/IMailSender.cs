using IhkObserver.Observer.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface IMailSender
    {
        public Task SendResultsAsync(IEnumerable<SubjectMarks> results);
    }
}
