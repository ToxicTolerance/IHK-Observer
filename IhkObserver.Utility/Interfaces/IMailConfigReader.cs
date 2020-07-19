using System.Threading.Tasks;

namespace IhkObserver.Utility.Interfaces
{
    public interface IMailConfigReader
    {
        public Task<IMailConfig> ReadAsync();
    }
}
