using IhkObserver.Mail.Interfaces;
using IhkObserver.Observer.Classes;
using IhkObserver.Text.Classes;
using IhkObserver.Text.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using IhkObserver.Mail.Classes;
using System.Drawing;
using System.Security.Policy;
using System.Linq;

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
            IGeneralConfig config = await new GeneralConfigReader().ReadAsync();
            await ConfigureAndStart(config);

            while (true)
            {
                // Just spin
            }
        }

        #region private methods

        private async Task ConfigureAndStart(IGeneralConfig config)
        {
            Credentials = new Credentials(config.AzubiIdentNr.ToString(), config.PrüflingsNr.ToString());

            Timer t = GetTimer(config.RepeatRunSpan);

            if (config.UseMailNotifications)
            {
                MailSender = new MailSender();
                Results = await GetResultsAsync();
                NewResults += async (object obj, EventArgs e) => { await MailSender.SendResultsAsync(obj, e, Results); };
            }

            if (config.NotifyOnStartup)
            {
                OnNewResults(null);
            }
        }

        private Timer GetTimer(TimeSpan callbackFrequency)
        {
            TimerCallback callback = async (object a) => { await CheckResults(); };
            return new Timer(callback, null, 0, callbackFrequency.Milliseconds);
        }

        private async Task CheckResults()
        {
            ResultReadWriter readWriter = new ResultReadWriter();
            IEnumerable<SubjectMarks> newResults = await GetResultsAsync();
            IEnumerable<SubjectMarks> oldResults = await readWriter.ReadAsync();

            if (newResults.Count() != oldResults.Count())
            {
                readWriter.Write(newResults);
                OnNewResults(null);
            }
        }

        private void OnNewResults(EventArgs e)
        {
            NewResults?.Invoke(this, e);
        }

        private async Task<IEnumerable<SubjectMarks>> GetResultsAsync()
        {
            // TODO (MG): Improve this
            string welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
            string login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
            string results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";

            Observer.IhkObserver observer = new Observer.IhkObserver(welcome, login, results, Credentials);
            string captcha = string.Empty;

            do
            {
                captcha = (await CaptchaSolver.CaptchaSolver.DeCaptchAsync(
                   await observer.GetLoginCaptchaAsync())).Item2;
            } while (!await observer.LoginAsync(captcha));

            return await observer.GetExamInformationAsync();
        }

        #endregion

        #endregion

        #region properties

        private IMailSender MailSender { get; set; }
        private IEnumerable<SubjectMarks> Results { get; set; }
        private Credentials Credentials { get; set; }

        #endregion
    }
}