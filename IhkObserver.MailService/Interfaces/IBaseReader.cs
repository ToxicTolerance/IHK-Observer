using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface IBaseConfigReader
    {
        public Task<string> ReadAsync(string path);
    }
}
