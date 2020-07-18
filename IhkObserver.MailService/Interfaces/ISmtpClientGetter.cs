using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpClientGetter
    {
        public Task InitializeSmtpClient();
    }
}
