using IhkObserver.Observer.Classes;
using IhkObserver.UI.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace IhkObserver.UI
{
    public static class ObserverHandler
    {
        #region[Delegates & Events]
        public delegate void DelegateCaptchaReceived(CaptchaEventArgs args);
        public delegate void DelegateCaptchaSolvedReceived(CaptchaSolvedEventArgs args);
        public delegate void DelegateLoginStatusReceived(LoginStatusEventArgs args);
        public delegate void DelegateExamsInformationsReceived(ExamsInformationEventArgs args);


        public static event DelegateCaptchaReceived OnCaptchaReceived;
        public static event DelegateLoginStatusReceived OnLoginStatusReceived;
        public static event DelegateCaptchaSolvedReceived OnCaptchaSolvedReceived;
        public static event DelegateExamsInformationsReceived OnExamsInformationReiceived;
        #endregion

        #region[Fields]
        private static Observer.IhkObserver _observer;
        #endregion

        #region[Constructor]
        static ObserverHandler()
        {
            _observer = new Observer.IhkObserver();
        }
        #endregion

        #region[Configuring]
        public static void ConfigureCredentials(Credentials credentials)
        {
            _observer.XmlConfig = credentials;

        }

        public static void ConfigureUrls(string urlLanding, string urlLogin, string urlResults)
        {
            _observer.UrlLandingPage = urlLanding;
            _observer.UrlLoginPage = urlLogin;
            _observer.UrlResultPage = urlResults;
        }
        #endregion

        #region [Login]
        public static async Task LoginAsync()
        {
            bool loggedIn = false;
            string valueOut;
            Bitmap outBmp;


            while (loggedIn == false)
            {
                // 1 - Get the Captcha
                Bitmap bmp = await _observer.GetLoginCaptchaAsync().ConfigureAwait(false);
                var bmpCopy = (Bitmap)bmp.Clone();

                // Fire event
                OnCaptchaReceived?.Invoke(new CaptchaEventArgs(bmpCopy));


                // 2 - Try to extract text. Getting the extracted text and the captcha
                (outBmp, valueOut) = await CaptchaSolver.CaptchaSolver.DeCaptchAsync(bmp).ConfigureAwait(false);

                // Fire event
                OnCaptchaSolvedReceived?.Invoke(new CaptchaSolvedEventArgs(outBmp, valueOut));

                // 3 - Await the login attempt
                loggedIn = await _observer.LoginAsync(valueOut).ConfigureAwait(false);

                OnLoginStatusReceived?.Invoke(new LoginStatusEventArgs(loggedIn));

                // 4 - If successfull, try to getting the Exams informations                
                if (loggedIn == true)
                {
                    List<SubjectMarks> marks = new List<SubjectMarks>();
                    marks = await _observer.GetExamInformationAsync().ConfigureAwait(false);

                    OnExamsInformationReiceived?.Invoke(new ExamsInformationEventArgs(marks));
                }

            }
        }
        #endregion
    }
}
