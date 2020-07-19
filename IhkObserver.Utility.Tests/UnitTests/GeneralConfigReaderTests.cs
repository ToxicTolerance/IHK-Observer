using IhkObserver.Utility.Classes;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.Utility.Tests.UnitTests
{
    public class GeneralConfigReaderTests
    {
        [Fact]
        public async Task ReadAsync()
        {
            Assert.NotNull(await new GeneralConfigReader().ReadAsync());
        }
    }
}
