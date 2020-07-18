using ControlzEx.Theming;
using System.Windows;

namespace IhkObserver.WpfResultViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
            base.OnStartup(e);
        }
    }
}
