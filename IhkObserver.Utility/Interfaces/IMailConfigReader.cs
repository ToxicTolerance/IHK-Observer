using System.Threading.Tasks;

namespace IhkObserver.Utility.Interfaces
{
    public interface IMailConfigReader
    {
        Task<IMailConfig> ReadAsync();
    }
}
