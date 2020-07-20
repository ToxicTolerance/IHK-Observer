namespace IhkObserver.UI.Classes
{
    class MetroMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessage(string message, string caption, System.Windows.Forms.MessageBoxButtons button, System.Windows.Forms.MessageBoxIcon icon)
        {
            System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;
            switch (button)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using (MetroMessageForm msgOK = new MetroMessageForm())
                    {
                        //Change text, caption, icon
                        msgOK.Text = caption;
                        msgOK.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                msgOK.MessageIcon = Properties.Resources.info;
                                break;

                        }
                        dlgResult = msgOK.ShowDialog();
                    }
                    break;
            }
            return dlgResult;
        }
    }


}
