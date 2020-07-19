using IhkObserver.Mail.Classes;
using IhkObserver.Observer.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IhkObserver.Mail.Tests.UnitTests
{
    [TestClass]
    public class MailSenderTests
    {
        [TestMethod]
        public async Task SendResultsAsync()
        {
            List<SubjectMarks> list = new List<SubjectMarks>
            {
                new SubjectMarks
                {
                    Mark = 18,
                    Points = 88,
                    Subject = "GA Deine Mama"
                },

                new SubjectMarks
                {
                    Mark = 1337,
                    Points = -12,
                    Subject = "Dei Vadda"
                }
            };

            await new MailSender().SendResultsAsync(null, null, list);
        }
    }
}
