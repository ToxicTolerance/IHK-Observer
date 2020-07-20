using System;
using System.Drawing;

namespace IhkObserver.UI.Classes
{
    public class CaptchaSolvedEventArgs : EventArgs
    {
        public Bitmap Captcha { get; set; }

        public string CaptchaString { get; set; }


        public CaptchaSolvedEventArgs(Bitmap captcha, string captchaString) : base()
        {
            Captcha = captcha;
            CaptchaString = captchaString;
        }
    }
}
