using IhkObserver.MailService.Exceptions;
using IhkObserver.MailService.Interfaces;
using MailKit.Net.Smtp;
using System;
using System.Threading.Tasks;

namespace IhkObserver.MailService.Classes
{
    public class GmailSmtpClientGetter : ISmtpClientGetter, IAsyncDisposable
    {
        #region methods

        #region ctor

        public GmailSmtpClientGetter()
        {
            Smtp = new SmtpClient();
        }

        public GmailSmtpClientGetter(ISmtpClient smtp)
        {
            Smtp = smtp;
        }

        #endregion

        #region public methods

        public async Task InitializeSmtpClient()
        {
            await Connect();
            await Authenticate();
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

        private async Task Connect()
        {
            try
            {
                await Smtp.ConnectAsync(Host, Port);
            }
            catch (Exception ex)
            {
                throw new SmtpNotConnectedException("Connection to smtp could not be made!", ex);
            }
        }

        private async Task Authenticate()
        {
            try
            {
                await Smtp.AuthenticateAsync("throwawayhurensohn@gmail.com", "password");
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
        private string Host => "smtp.gmail.com";
        private int Port => 465;

        #endregion
    }
}