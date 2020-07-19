using IhkObserver.Text.Interfaces;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace IhkObserver.Mail.Interfaces
{
    public interface ISmtpClientGetter
    {
        Task InitializeSmtpClientAsync(ISmtpConfig config);
        ISmtpClient Smtp { get; }
    }
}
