using System;

namespace IhkObserver.UI.Classes
{
    public class LoginStatusEventArgs : EventArgs
    {
        public bool Succesfull { get; set; }

        public LoginStatusEventArgs(bool succesfull) : base()
        {
            Succesfull = succesfull;
        }
    }
}
