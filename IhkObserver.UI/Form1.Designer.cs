namespace IhkObserver.UI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroControlBox1 = new MetroSuite.MetroControlBox();
            this.statusStrip = new MetroSuite.MetroStatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.metroTabControl1 = new MetroSuite.MetroTabControl();
            this.tpMarks = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCaptchaSolving = new MetroSuite.MetroPanelCategory();
            this.btnRelaod = new MetroSuite.MetroButton();
            this.lblCaptchaText = new MetroSuite.MetroLabel();
            this.metroLabel2 = new MetroSuite.MetroLabel();
            this.metroLabel1 = new MetroSuite.MetroLabel();
            this.lblCaptcha = new MetroSuite.MetroLabel();
            this.pbCaptchaManipulated = new System.Windows.Forms.PictureBox();
            this.pbCaptcha = new System.Windows.Forms.PictureBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanelCategory1 = new MetroSuite.MetroPanelCategory();
            this.metroLabel4 = new MetroSuite.MetroLabel();
            this.metroLabel3 = new MetroSuite.MetroLabel();
            this.tbPrNr = new MetroSuite.MetroTextbox();
            this.tbIdNr = new MetroSuite.MetroTextbox();
            this.metroButton1 = new MetroSuite.MetroButton();
            this.statusStrip.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tpMarks.SuspendLayout();
            this.panelCaptchaSolving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptchaManipulated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanelCategory1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroControlBox1
            // 
            this.metroControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroControlBox1.Location = new System.Drawing.Point(1103, 1);
            this.metroControlBox1.Name = "metroControlBox1";
            this.metroControlBox1.Size = new System.Drawing.Size(96, 32);
            this.metroControlBox1.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.ForeColor = System.Drawing.Color.Black;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 778);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Appearance = System.Windows.Forms.Appearance.Normal;
            this.metroTabControl1.AutoStyle = false;
            this.metroTabControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroTabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.metroTabControl1.Controls.Add(this.tpMarks);
            this.metroTabControl1.Controls.Add(this.tpSettings);
            this.metroTabControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroTabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.metroTabControl1.HasAnimation = false;
            this.metroTabControl1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(115)))), ((int)(((byte)(124)))));
            this.metroTabControl1.HeaderItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroTabControl1.HotTrack = true;
            this.metroTabControl1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroTabControl1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroTabControl1.ItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroTabControl1.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.metroTabControl1.ItemSize = new System.Drawing.Size(45, 120);
            this.metroTabControl1.Location = new System.Drawing.Point(12, 39);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroTabControl1.SelectedForeColor = System.Drawing.Color.White;
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.SelectedItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroTabControl1.SelectedItemLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroTabControl1.ShowToolTips = true;
            this.metroTabControl1.Size = new System.Drawing.Size(1176, 736);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.Style = MetroSuite.Design.Style.Dark;
            this.metroTabControl1.TabContainerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroTabControl1.TabIndex = 3;
            this.metroTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.metroTabControl1_Selected);
            // 
            // tpMarks
            // 
            this.tpMarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tpMarks.Controls.Add(this.flowLayoutPanel1);
            this.tpMarks.Controls.Add(this.panelCaptchaSolving);
            this.tpMarks.Location = new System.Drawing.Point(124, 4);
            this.tpMarks.Name = "tpMarks";
            this.tpMarks.Padding = new System.Windows.Forms.Padding(3);
            this.tpMarks.Size = new System.Drawing.Size(1048, 728);
            this.tpMarks.TabIndex = 0;
            this.tpMarks.Text = "Prüfungsergebnisse";
            this.tpMarks.ToolTipText = "Prüfungsergebnisse für dich";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 114);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1042, 611);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelCaptchaSolving
            // 
            this.panelCaptchaSolving.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelCaptchaSolving.BackColor = System.Drawing.Color.Transparent;
            this.panelCaptchaSolving.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelCaptchaSolving.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panelCaptchaSolving.Controls.Add(this.btnRelaod);
            this.panelCaptchaSolving.Controls.Add(this.lblCaptchaText);
            this.panelCaptchaSolving.Controls.Add(this.metroLabel2);
            this.panelCaptchaSolving.Controls.Add(this.metroLabel1);
            this.panelCaptchaSolving.Controls.Add(this.lblCaptcha);
            this.panelCaptchaSolving.Controls.Add(this.pbCaptchaManipulated);
            this.panelCaptchaSolving.Controls.Add(this.pbCaptcha);
            this.panelCaptchaSolving.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelCaptchaSolving.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaptchaSolving.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panelCaptchaSolving.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panelCaptchaSolving.GradientColor = System.Drawing.Color.White;
            this.panelCaptchaSolving.GradientPointA = new System.Drawing.Point(0, 0);
            this.panelCaptchaSolving.GradientPointB = new System.Drawing.Point(1042, 111);
            this.panelCaptchaSolving.LineGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.panelCaptchaSolving.Location = new System.Drawing.Point(3, 3);
            this.panelCaptchaSolving.Name = "panelCaptchaSolving";
            this.panelCaptchaSolving.Size = new System.Drawing.Size(1042, 111);
            this.panelCaptchaSolving.Style = MetroSuite.Design.Style.Dark;
            this.panelCaptchaSolving.TabIndex = 2;
            this.panelCaptchaSolving.Click += new System.EventHandler(this.panelCaptchaSolving_Click);
            // 
            // btnRelaod
            // 
            this.btnRelaod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelaod.BackColor = System.Drawing.Color.Transparent;
            this.btnRelaod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRelaod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.btnRelaod.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRelaod.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnRelaod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRelaod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.btnRelaod.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.btnRelaod.Location = new System.Drawing.Point(820, 45);
            this.btnRelaod.Name = "btnRelaod";
            this.btnRelaod.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRelaod.RoundingArc = 50;
            this.btnRelaod.Size = new System.Drawing.Size(200, 50);
            this.btnRelaod.Style = MetroSuite.Design.Style.Dark;
            this.btnRelaod.TabIndex = 6;
            this.btnRelaod.Text = "Manual Reload";
            this.btnRelaod.Click += new System.EventHandler(this.btnRelaod_Click);
            // 
            // lblCaptchaText
            // 
            this.lblCaptchaText.AutoSize = true;
            this.lblCaptchaText.BackColor = System.Drawing.Color.Transparent;
            this.lblCaptchaText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptchaText.Location = new System.Drawing.Point(673, 54);
            this.lblCaptchaText.Name = "lblCaptchaText";
            this.lblCaptchaText.Size = new System.Drawing.Size(65, 32);
            this.lblCaptchaText.TabIndex = 5;
            this.lblCaptchaText.Text = "-----";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroLabel2.Location = new System.Drawing.Point(627, 15);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(157, 15);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Captcha Image Manipulated";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroLabel1.Location = new System.Drawing.Point(375, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(157, 15);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Captcha Image Manipulated";
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.BackColor = System.Drawing.Color.Transparent;
            this.lblCaptcha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaptcha.Location = new System.Drawing.Point(168, 15);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(87, 15);
            this.lblCaptcha.TabIndex = 2;
            this.lblCaptcha.Text = "Captcha Image";
            // 
            // pbCaptchaManipulated
            // 
            this.pbCaptchaManipulated.Location = new System.Drawing.Point(353, 45);
            this.pbCaptchaManipulated.Name = "pbCaptchaManipulated";
            this.pbCaptchaManipulated.Size = new System.Drawing.Size(195, 50);
            this.pbCaptchaManipulated.TabIndex = 1;
            this.pbCaptchaManipulated.TabStop = false;
            // 
            // pbCaptcha
            // 
            this.pbCaptcha.Location = new System.Drawing.Point(111, 45);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new System.Drawing.Size(195, 50);
            this.pbCaptcha.TabIndex = 0;
            this.pbCaptcha.TabStop = false;
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tpSettings.Controls.Add(this.tableLayoutPanel1);
            this.tpSettings.Location = new System.Drawing.Point(124, 4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1048, 728);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Einstellungen";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.metroPanelCategory1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroButton1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 371F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 722);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroPanelCategory1
            // 
            this.metroPanelCategory1.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroPanelCategory1.BackColor = System.Drawing.Color.Transparent;
            this.metroPanelCategory1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroPanelCategory1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.metroPanelCategory1.Controls.Add(this.metroLabel4);
            this.metroPanelCategory1.Controls.Add(this.metroLabel3);
            this.metroPanelCategory1.Controls.Add(this.tbPrNr);
            this.metroPanelCategory1.Controls.Add(this.tbIdNr);
            this.metroPanelCategory1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroPanelCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelCategory1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroPanelCategory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.metroPanelCategory1.GradientColor = System.Drawing.Color.White;
            this.metroPanelCategory1.GradientPointA = new System.Drawing.Point(0, 0);
            this.metroPanelCategory1.GradientPointB = new System.Drawing.Point(1036, 154);
            this.metroPanelCategory1.LineGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(163)))));
            this.metroPanelCategory1.Location = new System.Drawing.Point(3, 3);
            this.metroPanelCategory1.Name = "metroPanelCategory1";
            this.metroPanelCategory1.Size = new System.Drawing.Size(1036, 154);
            this.metroPanelCategory1.Style = MetroSuite.Design.Style.Dark;
            this.metroPanelCategory1.TabIndex = 0;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroLabel4.Location = new System.Drawing.Point(15, 90);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(104, 15);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Prüfungsnummer:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroLabel3.Location = new System.Drawing.Point(15, 45);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(131, 15);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Identifikationsnummer:";
            // 
            // tbPrNr
            // 
            this.tbPrNr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbPrNr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.tbPrNr.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbPrNr.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tbPrNr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPrNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbPrNr.HideSelection = false;
            this.tbPrNr.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tbPrNr.Location = new System.Drawing.Point(173, 82);
            this.tbPrNr.Name = "tbPrNr";
            this.tbPrNr.PasswordChar = '\0';
            this.tbPrNr.Size = new System.Drawing.Size(134, 23);
            this.tbPrNr.Style = MetroSuite.Design.Style.Dark;
            this.tbPrNr.TabIndex = 1;
            // 
            // tbIdNr
            // 
            this.tbIdNr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbIdNr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.tbIdNr.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbIdNr.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tbIdNr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbIdNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbIdNr.HideSelection = false;
            this.tbIdNr.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tbIdNr.Location = new System.Drawing.Point(173, 45);
            this.tbIdNr.Name = "tbIdNr";
            this.tbIdNr.PasswordChar = '\0';
            this.tbIdNr.Size = new System.Drawing.Size(134, 23);
            this.tbIdNr.Style = MetroSuite.Design.Style.Dark;
            this.tbIdNr.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Transparent;
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.metroButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.metroButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.metroButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.metroButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.metroButton1.Location = new System.Drawing.Point(957, 694);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.metroButton1.RoundingArc = 25;
            this.metroButton1.Size = new System.Drawing.Size(82, 25);
            this.metroButton1.Style = MetroSuite.Design.Style.Dark;
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Save Settings";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.metroControlBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainControlBox = this.metroControlBox1;
            this.Name = "Form1";
            this.State = MetroSuite.MetroForm.FormState.Normal;
            this.Style = MetroSuite.Design.Style.Dark;
            this.Text = "Ihk Marks";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.tpMarks.ResumeLayout(false);
            this.panelCaptchaSolving.ResumeLayout(false);
            this.panelCaptchaSolving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptchaManipulated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanelCategory1.ResumeLayout(false);
            this.metroPanelCategory1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroSuite.MetroControlBox metroControlBox1;
        private MetroSuite.MetroStatusStrip statusStrip;
        private MetroSuite.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tpMarks;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroSuite.MetroPanelCategory panelCaptchaSolving;
        private MetroSuite.MetroButton btnRelaod;
        private MetroSuite.MetroLabel lblCaptchaText;
        private MetroSuite.MetroLabel metroLabel2;
        private MetroSuite.MetroLabel metroLabel1;
        private MetroSuite.MetroLabel lblCaptcha;
        private System.Windows.Forms.PictureBox pbCaptchaManipulated;
        private System.Windows.Forms.PictureBox pbCaptcha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroSuite.MetroPanelCategory metroPanelCategory1;
        private MetroSuite.MetroLabel metroLabel4;
        private MetroSuite.MetroLabel metroLabel3;
        private MetroSuite.MetroTextbox tbPrNr;
        private MetroSuite.MetroTextbox tbIdNr;
        private MetroSuite.MetroButton metroButton1;
    }
}

