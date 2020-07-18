using IhkObserver.MailService.Classes;
using IhkObserver.MailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.MailService.Tests.UnitTests
{
    public class SmtpConfigReaderTests
    {
        [Fact]
        public async Task ReadAsync_Successful()
        {
            SmtpConfigReader reader = new SmtpConfigReader();
            ISmtpConfig config = await reader.ReadAsync();
        }
    }
}
