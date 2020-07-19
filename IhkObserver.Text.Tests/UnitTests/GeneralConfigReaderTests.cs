using IhkObserver.Text.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IhkObserver.Text.Tests.UnitTests
{
    [TestClass]
    public class GeneralConfigReaderTests
    {
        [TestMethod]
        public async Task ReadAsync()
        {
            Assert.IsNotNull(await new GeneralConfigReader().ReadAsync());
        }
    }
}
