using IhkObserver.MailService.Exceptions;
using IhkObserver.MailService.Interfaces;
using IhkObserver.Utility.Interfaces;
using MailKit.Net.Smtp;
using System;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class SmtpClientGetter : ISmtpClientGetter, IAsyncDisposable
    {
        #region methods

        #region ctor

        public SmtpClientGetter()
        {
            Smtp = new SmtpClient();
        }

        public SmtpClientGetter(ISmtpClient smtp)
        {
            Smtp = smtp;
        }

        #endregion

        #region public methods

        public async Task InitializeSmtpClientAsync(IMailConfig config)
        {
            await ConnectAsync(config.SmtpSetting);
            await AuthenticateAsync(config);
        }

        public async ValueTask DisposeAsync()
        {
            if (Smtp.IsConnected)
            {
                try
                {
                    await Smtp.DisconnectAsync(true);
                }
                catch (ObjectDisposedException)
                {

                }
            }
            Smtp = null;
        }

        #endregion

        #region private methods

        private async Task ConnectAsync(ISmtpConfig config)
        {
            try
            {
                await Smtp.ConnectAsync(config.Host, config.Port);
            }
            catch (Exception ex)
            {
                throw new SmtpNotConnectedException("Connection to smtp could not be made!", ex);
            }
        }

        private async Task AuthenticateAsync(IMailConfig config)
        {
            try
            {
                await Smtp.AuthenticateAsync(config.SendFrom, config.SmtpSetting.SenderPassword);
            }
            catch (Exception ex)
            {
                throw new SmtpNotAuthenticatedException("Could not authenticate at smtp server", ex);
            }
        }

        #endregion

        #endregion

        #region properties

        public ISmtpClient Smtp { get; private set; }

        #endregion
    }
}