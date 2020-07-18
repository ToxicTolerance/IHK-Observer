using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpConfigReader
    {
        public Task<ISmtpConfig> ReadAsync();
    }
}
