using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    public class HomeViewModel : MenuItemViewModel
    {

        List<SubjectMarks> _marks;

        private ImageSource _captcha;
        private ImageSource _captchaFiltered;
        private ICommand _loadResults;
        private string _captchaText;

        private Observer.IhkObserver _observer;

        private const string _welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
        private const string _login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
        private const string _results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";


        public List<SubjectMarks> SubjectMarks
        {
            get { return this._marks; }
            set
            {
                this._marks = value;
                OnPropertyChanged();
            }
        }
        public ImageSource CaptchaFiltered
        {
            get { return this._captchaFiltered; }
            set
            {
                this._captchaFiltered = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Captcha
        {
            get { return this._captcha; }
            set
            {
                this._captcha = value;
                OnPropertyChanged();
            }
        }

        public string CaptchaText
        {
            get { return this._captchaText; }
            set
            {
                this._captchaText = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadResultsCommand
        {
            get
            {
                if (this._loadResults == null)
                {
                    this._loadResults = new RelayCommand(p => ExecuteLoadResults());
                }
                return this._loadResults;
            }

        }



        public HomeViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            XmlConfig config = new XmlConfig("2508139", "20735");
            config.SaveXmlConfig(Directory.GetCurrentDirectory() + "\\config.xml");

            _observer = new Observer.IhkObserver(_welcome, _login, _results, config);

            _observer.AddSessionId();

            _observer.GetLoginInformations();


        }





        private void ExecuteLoadResults()
        {
            _observer.AddSessionId();

            _observer.GetLoginInformations();

            Bitmap map = _observer.GetLoginCaptcha();
            Captcha = BitmapConversion.BitmapToBitmapSource(map);

            string text;
            CaptchaFiltered = BitmapConversion.BitmapToBitmapSource(CaptchaSolver.CaptchaSolver.DeCaptcha(map, out text));

            CaptchaText = text;
            bool login = _observer.Login(text);


            List<SubjectMarks> marks = new List<SubjectMarks>();
            if (login == true)
            {

                _observer.GetExamInformation(out marks);
            }

            SubjectMarks = marks;
        }


    }

    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
    }

}
