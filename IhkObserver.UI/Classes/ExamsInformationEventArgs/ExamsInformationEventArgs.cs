using IhkObserver.Observer.Classes;
using System;
using System.Collections.Generic;

namespace IhkObserver.UI.Classes
{
    public class ExamsInformationEventArgs : EventArgs
    {
        public List<SubjectMarks> Results { get; set; }
        public ExamsInformationEventArgs(List<SubjectMarks> results) : base()
        {
            Results = results;
        }
    }
}
