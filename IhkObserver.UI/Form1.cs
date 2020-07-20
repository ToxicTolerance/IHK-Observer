using IhkObserver.UI.Classes;
using MetroSuite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IhkObserver.UI
{
    public partial class Form1 : MetroForm
    {

        #region[Constants]
        //Constant URLS of the Website
        private const string _welcome = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Willkommen.aspx?knr=155";
        private const string _login = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Login.aspx";
        private const string _results = "https://ausbildung.ihk.de/pruefungsinfos/Peo/Ergebnisse.aspx";
        #endregion

        public Form1()
        {
            InitializeComponent();

            bool configured = CheckConfig();


            UpdateStatusLabel("Configuring Observer");
            ObserverHandler.ConfigureUrls(_welcome, _login, _results);
            ObserverHandler.ConfigureCredentials(new Observer.Classes.Credentials("0000000", "00000"));



        }

        private async void Form1_Load(object sender, System.EventArgs e)
        {
            UpdateStatusLabel("Subscribe Observer");

            ObserverHandler.OnCaptchaReceived += ObserverHandler_OnCaptchaReceived;
            ObserverHandler.OnCaptchaSolvedReceived += ObserverHandler_OnCaptchaSolvedReceived;
            ObserverHandler.OnLoginStatusReceived += ObserverHandler_OnLoginStatusReceived;
            ObserverHandler.OnExamsInformationReiceived += ObserverHandler_OnExamsInformationReiceived;

            UpdateStatusLabel("Trying to Login");

            ProceedLogin();
        }

        private void ObserverHandler_OnExamsInformationReiceived(Classes.ExamsInformationEventArgs args)
        {
            int count = args.Results.Count;
            UpdateStatusLabel($"{count} Results loaded");

            List<ExamPanel> panels = new List<ExamPanel>();

            foreach (var info in args.Results)
            {
                ExamPanel panel = new ExamPanel();
                panel.Fach = info.Subject;
                panel.Mark = info.Mark.ToString();
                panel.Points = info.Points.ToString();
                panel.Enabled = true;

                panels.Add(panel);
            }
            flowLayoutPanel1.Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.AddRange(panels.ToArray())));

        }

        private void ObserverHandler_OnLoginStatusReceived(Classes.LoginStatusEventArgs args)
        {
            switch (args.Succesfull)
            {
                case true:
                    {
                        UpdateStatusLabel("Login Successfull");
                    }
                    break;
                case false:
                    {
                        UpdateStatusLabel("Login not Successfull");
                    }
                    break;
            }
        }

        private void ObserverHandler_OnCaptchaSolvedReceived(Classes.CaptchaSolvedEventArgs args)
        {
            UpdateStatusLabel("Captchs Modified Received");
            pbCaptchaManipulated.Invoke((MethodInvoker)(() => pbCaptchaManipulated.Image = args.Captcha));
            lblCaptchaText.Invoke((MethodInvoker)(() => lblCaptchaText.Text = args.CaptchaString));
        }

        private void ObserverHandler_OnCaptchaReceived(Classes.CaptchaEventArgs args)
        {
            UpdateStatusLabel("Captchs  Received");
            pbCaptcha.Invoke((MethodInvoker)(() => pbCaptcha.Image = args.Captcha));

        }


        private void UpdateStatusLabel(string text)
        {
            statusLabel.Text = text;
        }

        private void btnRelaod_Click(object sender, EventArgs e)
        {
            ProceedLogin();
        }


        private async void ProceedLogin()
        {
            flowLayoutPanel1.Controls.Clear();
            await ObserverHandler.LoginAsync();

        }


        private bool CheckConfig()
        {
            bool returnVal = false;

            string idNr = Properties.Settings.Default.Identifikationsnummer;
            string prNr = Properties.Settings.Default.Prüfungsnummer;

            if (string.IsNullOrWhiteSpace(idNr) || string.IsNullOrWhiteSpace(prNr))
            {
                returnVal = false;

            }
            else
            {
                returnVal = true;
            }

            return returnVal;
        }

        private void panelCaptchaSolving_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }



        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tpMarks":
                    {
                    }
                    break;
                case "tpSettings":
                    {

                    }
                    break;
            }
        }
    }
}