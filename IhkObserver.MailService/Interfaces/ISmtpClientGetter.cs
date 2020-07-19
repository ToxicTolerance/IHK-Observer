using IhkObserver.Utility.Interfaces;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpClientGetter
    {
        public Task InitializeSmtpClientAsync(ISmtpConfig config);
        public ISmtpClient Smtp { get; }
    }
}
