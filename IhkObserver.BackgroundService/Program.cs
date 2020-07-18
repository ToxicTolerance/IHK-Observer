using System;
using System.Threading;

namespace IhkObserver.BackgroundService
{
    public class Program
    {
        public static void Main()
        {

        }

        public void StartListening()
        {
            TimerCallback callback = (object a) => { CheckResults(); };
            Timer t = new Timer(callback, null, 0, 10000);
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
        }

        private void CheckResults()
        {
            if (true)
            {
                OnNewResults(null);
            }
        }

        public event EventHandler NewResults;

        private void OnNewResults(EventArgs e)
        {
            NewResults?.Invoke(this, e);
        }
    }
}
