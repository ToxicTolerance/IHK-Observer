using System.Threading.Tasks;

namespace IhkObserver.Text.Interfaces
{
    public interface IMailConfigReader
    {
        Task<IMailConfig> ReadAsync();
    }
}
