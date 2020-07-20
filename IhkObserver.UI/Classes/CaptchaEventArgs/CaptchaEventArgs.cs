using System;
using System.Drawing;

namespace IhkObserver.UI.Classes
{
    public class CaptchaEventArgs : EventArgs
    {
        public Bitmap Captcha { get; set; }

        public CaptchaEventArgs(Bitmap captcha) : base()
        {
            Captcha = captcha;
        }

    }
}
