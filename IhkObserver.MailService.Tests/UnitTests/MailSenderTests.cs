using IhkObserver.MailService.Classes;
using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.MailService.Tests.UnitTests
{
    public class MailSenderTests
    {
        [Fact]
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

            await new MailSender().SendResultsAsync(list);
        }
    }
}
