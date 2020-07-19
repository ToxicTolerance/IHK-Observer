using System.Threading.Tasks;

namespace IhkObserver.Utility.Interfaces
{
    public interface IGeneralConfigReader
    {
        Task<IGeneralConfig> ReadAsync();
    }
}
