using IhkObserver.Mail.Exceptions;
using IhkObserver.Mail.Interfaces;
using IhkObserver.Text.Interfaces;
using MailKit.Net.Smtp;
using System;
using System.Threading.Tasks;

namespace IhkObserver.Mail.Classes
{
    public class SmtpClientGetter : ISmtpClientGetter, IDisposable
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

        public async Task InitializeSmtpClientAsync(ISmtpConfig config)
        {
            await ConnectAsync(config);
            await AuthenticateAsync(config);
        }

        public void Dispose()
        {
            if (Smtp.IsConnected)
            {
                try
                {
                    Smtp.Disconnect(true);
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

        private async Task AuthenticateAsync(ISmtpConfig config)
        {
            try
            {
                await Smtp.AuthenticateAsync(config.Mail, config.SenderPassword);
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