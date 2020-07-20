<!--<a href="http://fvcproductions.com"><img src="https://avatars1.githubusercontent.com/u/4284691?v=3&s=200" title="FVCproductions" alt="FVCproductions"></a>-->

<!-- [![FVCproductions](https://avatars1.githubusercontent.com/u/4284691?v=3&s=200)](http://fvcproductions.com) -->



# IHK Observer

> A tiny Program for automated observing of the IHK Final Exams Results


[![Build Status](http://img.shields.io/travis/badges/badgerbadgerbadger.svg?style=flat-square)](https://travis-ci.org/badges/badgerbadgerbadger) 
[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org) 



---

## Example (Optional)

```csharp
// code away!
// sample code for Using the Observer in your own project

		private void Login()
        {
			
			bool loggedIn = false;
            string valueOut;
            Bitmap outBmp;

            //URL's
            string welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
            string login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
            string results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";

            // Create a config with your credentials
            XmlConfig config = new XmlConfig("0000000", "00000");
            config.SaveXmlConfig(Directory.GetCurrentDirectory() + "\\config.xml");

            //Create new Instance of observer
            Observer.IhkObserver observer = new Observer.IhkObserver(welcome, login, results, config);
					
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
		}
```

---


### Clone

- Clone this repo to your local machine using `https://github.com/ToxicTolerance/IHK-Observer.git`


## Special Thanks to...

- * [@emre1702](https://github.com/emre1702/IHK-Pruefungsergebnisse-Ausleser) - for his initial work on webparsing the IHK-Website
- * [@judero01col](https://github.com/judero01col/Captcha-Solver) - for his initial work on his captchaSolver which i adapted and improved for this.

---

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2015 © <a href="http://fvcproductions.com" target="_blank">FVCproductions</a>.