using IhkObserver.CaptchaSolver;
using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Xunit;

namespace Testorino
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //URL's
            string welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
            string login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
            string results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";


            IhkObserver.Observer.IhkObserver observer = new IhkObserver.Observer.IhkObserver(welcome, login, results, new Credentials("2899730", "20259"));

            //Get the captcha as bitmap
            Bitmap map = observer.GetLoginCaptcha();

            // Try to solve the captcha
            //returns a manipulated (applied some filtering etc.) version of input Bitmap            
            //and outputs the (hopefully correct) string via out-keyword
            string text;
            Bitmap mapFiltered = CaptchaSolver.DeCaptcha(map, out text);

            // Attempt login
            bool loggedIn = observer.Login(text);

            //If successfully logged in, try to get the Exams Results
            if (loggedIn == true)
            {
                List<SubjectMarks> marks = new List<SubjectMarks>();
                observer.GetExamInformation(out marks);
            }
        }
    }
}
