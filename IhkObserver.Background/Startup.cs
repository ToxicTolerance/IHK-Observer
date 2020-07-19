using IhkObserver.Mail.Interfaces;
using IhkObserver.Observer.Classes;
using IhkObserver.Text.Classes;
using IhkObserver.Text.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using IhkObserver.Mail.Classes;

namespace IhkObserver.BackgroundService
{
    public class Startup
    {
        #region event

        public event EventHandler NewResults;

        #endregion

        #region methods

        public static void Main()
        {
            new Startup().Start().Wait();
        }

        /// <summary>
        /// Starts Program and runs infinitely.
        /// </summary>
        public async Task Start()
        {
            Configure(await new GeneralConfigReader().ReadAsync());
            IGeneralConfig config = await new GeneralConfigReader().ReadAsync();





        }

        #region private methods

        private void Configure(IGeneralConfig config)
        {
            AzubiIdentNr = config.AzubiIdentNr;
            PrüflingsNr = config.PrüflingsNr;

            Timer t = GetTimer(config.RepeatRunSpan);

            if (config.UseMailNotifications)
            {
                MailSender = new MailSender();
                NewResults += async (object obj, EventArgs e) => { await MailSender.SendResultsAsync(obj, e, Results); };
            }

            if (config.NotifyOnStartup)
            {
                OnNewResults(null);
            }
        }

        private Timer GetTimer(TimeSpan callbackFrequency)
        {
            TimerCallback callback = (object a) => { CheckResults(); };
            return new Timer(callback, null, 0, callbackFrequency.Milliseconds);
        }

        private void CheckResults()
        {
            if (true)
            {
                // Call event
            }
        }

        private void OnNewResults(EventArgs e)
        {
            NewResults?.Invoke(this, e);
        }

        #endregion

        #endregion

        #region properties

        private int AzubiIdentNr { get; set; }
        private int PrüflingsNr { get; set; }
        private IMailSender MailSender { get; set; }
        private IEnumerable<SubjectMarks> Results { get; set; }

        #endregion
    }
}