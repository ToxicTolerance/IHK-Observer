<a href="http://fvcproductions.com"><img src="https://avatars1.githubusercontent.com/u/4284691?v=3&s=200" title="FVCproductions" alt="FVCproductions"></a>

<!-- [![FVCproductions](https://avatars1.githubusercontent.com/u/4284691?v=3&s=200)](http://fvcproductions.com) -->

***INSERT GRAPHIC HERE (include hyperlink in image)***

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
            //URL's
            string welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
            string login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
            string results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";

            // Create a config with your credentials
            XmlConfig config = new XmlConfig("0000000", "00000");
            config.SaveXmlConfig(Directory.GetCurrentDirectory() + "\\config.xml");

            //Create new Instance of observer
            Observer.IhkObserver observer = new Observer.IhkObserver(welcome, login, results, config);

            //Adds a session Id for this session
            observer.AddSessionId();

            //Extracts loginInformations (URL to ViewState etc. -> ASPX) from the Website
            observer.GetLoginInformations();

            //Get the captcha as bitmap
            Bitmap map = _observer.GetLoginCaptcha();

            // Try to solve the captcha
            //returns a manipulated (applied some filtering etc.) version of input Bitmap            
            //and outputs the (hopefully correct) string via out-keyword
            string text;
            Bitmap mapFiltered = CaptchaSolver.CaptchaSolver.DeCaptcha(map, out text);
            
            // Attempt login
            bool loggedIn = observer.Login(text);

            //If successfully logged in, try to get the Exams Results
            if (loggedIn == true)
            {
                List<SubjectMarks> marks = new List<SubjectMarks>();
                observer.GetExamInformation(out marks);
            }
        }
```

---


### Clone

- Clone this repo to your local machine using `https://github.com/ToxicTolerance/IHK-Observer.git`




## Special Thanks to...

Reach out to me at one of the following places!

- Special thanks to @emre1702 for his initial work on webparsing the IHK-Website
- Special thanks to @judero01col for his initial work on his captchaSolver which i adapted and improved for this.

---

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2015 © <a href="http://fvcproductions.com" target="_blank">FVCproductions</a>.