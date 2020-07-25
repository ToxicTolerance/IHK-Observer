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

        #region[Constructor]
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {



        }
        #endregion

        #region[ObserverHandler Events]
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
        #endregion

        #region[Control Events]

        private void Form1_Shown(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ProceedLogin();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Identifikationsnummer = tbIdentNumber.Text;
            Properties.Settings.Default.Prüfungsnummer = tbExamNumber.Text;

            Properties.Settings.Default.Save();
        }

        private void TextBox_textChanged(object sender, EventArgs e)
        {
            bool buttonEnabled = ValidateIdentNumber() && ValidateExamNumber();
            btnSaveConfig.Enabled = buttonEnabled;
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tpMarks":
                    {
                        Initialize();
                    }
                    break;
                case "tpSettings":
                    {
                        tbExamNumber.Text = Properties.Settings.Default.Prüfungsnummer;
                        tbIdentNumber.Text = Properties.Settings.Default.Identifikationsnummer;

                    }
                    break;
            }
        }

        #endregion

        #region[Methods]
        /// <summary>
        /// Just simpler to use
        /// </summary>
        /// <param name="text"></param>
        private void UpdateStatusLabel(string text)
        {
            statusLabel.Text = text;
        }

        /// <summary>
        /// Clears all Exam Informations and reloads them from the Web
        /// </summary>
        private async void ProceedLogin()
        {
            flowLayoutPanel1.Controls.Clear();
            await ObserverHandler.LoginAsync();

        }

        /// <summary>
        /// Checks if a config is available.
        /// Should only be the case on first startup.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Initial check for existing configuration and initializting the
        /// <see cref="ObserverHandler"/>.
        /// </summary>
        private void Initialize()
        {
            bool configured = CheckConfig();

            if (configured == false)
            {
                if (MetroMessageBox.ShowMessage("Bitte gib zuerst deine Daten ein!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    metroTabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                UpdateStatusLabel("Configuring Observer");

                ObserverHandler.ConfigureUrls(_welcome, _login, _results);
                ObserverHandler.ConfigureCredentials(new Observer.Classes.Credentials(Properties.Settings.Default.Identifikationsnummer, Properties.Settings.Default.Prüfungsnummer));

                UpdateStatusLabel("Subscribe Observer");

                ObserverHandler.OnCaptchaReceived += ObserverHandler_OnCaptchaReceived;
                ObserverHandler.OnCaptchaSolvedReceived += ObserverHandler_OnCaptchaSolvedReceived;
                ObserverHandler.OnLoginStatusReceived += ObserverHandler_OnLoginStatusReceived;
                ObserverHandler.OnExamsInformationReiceived += ObserverHandler_OnExamsInformationReiceived;

                UpdateStatusLabel("Trying to Login");

                ProceedLogin();
            }
        }

        /// <summary>
        /// Validates if the Identnumber 
        /// is in the correct format.
        /// </summary>
        /// <returns></returns>
        private bool ValidateIdentNumber()
        {
            bool bStatus = true;
            if (string.IsNullOrWhiteSpace(tbIdentNumber.Text))
            {
                epIdentNumber.SetError(tbIdentNumber, "Please enter your Identnumber");
                bStatus = false;
            }
            else
            {
                epIdentNumber.SetError(tbIdentNumber, "");
                try
                {
                    int number = int.Parse(tbIdentNumber.Text);


                    int length = tbIdentNumber.Text.Length;
                    epIdentNumber.SetError(tbIdentNumber, "");
                    if (length != 7)
                    {
                        epIdentNumber.SetError(tbIdentNumber, "Your must Identnumber must be 7 Charakters long");
                        bStatus = false;
                    }
                    else
                    {
                        epIdentNumber.SetError(tbIdentNumber, "");
                    }
                }
                catch
                {
                    epIdentNumber.SetError(tbIdentNumber, "Please enter your Identnumber as a number");
                    bStatus = false;
                }
            }
            return bStatus;
        }

        /// <summary>
        /// Validates if the Examnumber 
        /// is in the correct format.
        /// </summary>
        /// <returns></returns>
        private bool ValidateExamNumber()
        {
            bool bStatus = true;
            if (string.IsNullOrWhiteSpace(tbExamNumber.Text))
            {
                epExamNumber.SetError(tbExamNumber, "Please enter your Examnumber");
                bStatus = false;
            }
            else
            {
                epExamNumber.SetError(tbExamNumber, "");
                try
                {
                    int length = tbExamNumber.Text.Length;
                    epExamNumber.SetError(tbExamNumber, "");
                    if (length != 5)
                    {
                        epExamNumber.SetError(tbExamNumber, "Your must Examnumber must be 5 Charakters long");
                        bStatus = false;
                    }
                    else
                    {
                        epExamNumber.SetError(tbExamNumber, "");
                    }
                }
                catch
                {
                    epExamNumber.SetError(tbExamNumber, "Please enter your Examnumber as a number");
                    bStatus = false;
                }
            }
            return bStatus;
        }
        #endregion
    }
}