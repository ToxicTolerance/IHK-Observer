using IhkObserver.BackgroundService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IhkObserver.Background.Tests
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public async Task TestResults()
        {
            Startup.Main();
        }
    }
}
