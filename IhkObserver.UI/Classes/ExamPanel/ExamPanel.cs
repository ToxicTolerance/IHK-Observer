using System.Windows.Forms;

namespace IhkObserver.UI.Classes
{
    public partial class ExamPanel : UserControl
    {
        private string fach;

        public string Fach
        {
            get { return fach; }
            set
            {
                fach = value;
                lblFach.Text = value;
            }
        }

        private string note;

        public string Mark
        {
            get { return note; }
            set
            {

                note = value;
                lblNote.Text = value;
            }
        }

        private string points;

        public string Points
        {
            get { return points; }
            set
            {
                points = value;
                lblPunkte.Text = value;
            }
        }


        public ExamPanel()
        {
            InitializeComponent();
            this.metroPanelCategory1.Enabled = true;
            this.metroPanelCategory1.Style = MetroSuite.Design.Style.Dark;
        }

    }
}
