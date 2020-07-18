using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface IMailConfigReader
    {
        public Task<IMailConfig> ReadAsync();
    }
}
