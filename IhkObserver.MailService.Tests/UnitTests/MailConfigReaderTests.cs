using IhkObserver.MailService.Classes;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.MailService.Tests.UnitTests
{
    public class MailConfigReaderTests
    {
        [Fact]
        public async Task ReadAsync()
        {
            Assert.NotNull(await new MailConfigReader().ReadAsync());
        }
    }
}
