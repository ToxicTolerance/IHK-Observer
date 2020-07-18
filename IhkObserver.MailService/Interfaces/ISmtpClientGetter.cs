using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpClientGetter
    {
        public Task InitializeSmtpClientAsync(IMailConfig config);
        public ISmtpClient Smtp { get; }
    }
}
