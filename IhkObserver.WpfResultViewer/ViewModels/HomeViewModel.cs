using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    public class HomeViewModel : MenuItemViewModel
    {
        #region [Fields]

        // Marks for each subject  received from IHK
        private List<SubjectMarks> _marks;

        // Observer which handles the interactions with the 
        // IHK Website        
        private Observer.IhkObserver _observer;

        #endregion

        #region[Constants]
        //Constant URLS of the Website
        private const string _welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
        private const string _login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
        private const string _results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";
        #endregion

        #region[Properties]
        /// <summary>
        /// 
        /// </summary>
        public List<SubjectMarks> SubjectMarks
        {
            get { return this._marks; }
            set
            {
                this._marks = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Executes directly the Loading
        /// </summary>
        private async void ExecuteLoadResults()
        {
            await TryLoginAsync();
        }
        #endregion

        #region[Constructor]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainViewModel"></param>
        public HomeViewModel(MainViewModel mainViewModel, Credentials cred) : base(mainViewModel)
        {
            // Create observer instance
            _observer = new Observer.IhkObserver(_welcome, _login, _results, cred);

            //Directly load
            ExecuteLoadResults();
        }
        #endregion

        #region[Try Login]
        /// <summary>
        /// One simple async Task for logging in and receiveing the Exams informations
        /// </summary>
        /// <returns></returns>
        private async Task TryLoginAsync()
        {
            bool loggedIn = false;
            string valueOut;
            Bitmap outBmp;

            while (loggedIn == false)
            {
                // 1 - Get the Captcha
                Bitmap bmp = await _observer.GetLoginCaptchaAsync().ConfigureAwait(false);

                // 2 - Try to extract text. Getting the extracted text and the captcha
                (outBmp, valueOut) = await CaptchaSolver.CaptchaSolver.DeCaptchAsync(bmp).ConfigureAwait(false);

                // 3 - Await the login attempt
                loggedIn = await _observer.LoginAsync(valueOut).ConfigureAwait(false);

                // 4 - If successfull, try to getting the Exams informations                
                if (loggedIn == true)
                {
                    List<SubjectMarks> marks = new List<SubjectMarks>();
                    marks = await _observer.GetExamInformationAsync().ConfigureAwait(false);

                    // Dispatch to UI 
                    Application.Current.Dispatcher.Invoke(new Action(() => { SubjectMarks = marks; }));
                }

                //Not used because i dont show any infos about the captchas now
                //Application.Current.Dispatcher.Invoke(new Action(() => { Captcha = BitmapConversion.BitmapToBitmapSource(bmp); }));
                //Application.Current.Dispatcher.Invoke(new Action(() => { CaptchaFiltered = BitmapConversion.BitmapToBitmapSource(outBmp); }));
                //Application.Current.Dispatcher.Invoke(new Action(() => { CaptchaText = valueOut; }));

            }
        }
        #endregion
    }
}
