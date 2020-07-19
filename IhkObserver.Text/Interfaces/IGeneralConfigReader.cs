using System.Threading.Tasks;

namespace IhkObserver.Text.Interfaces
{
    public interface IGeneralConfigReader
    {
        Task<IGeneralConfig> ReadAsync();
    }
}
