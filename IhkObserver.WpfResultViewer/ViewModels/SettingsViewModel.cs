using IhkObserver.Observer.Classes;
using System.Configuration;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    class SettingsViewModel : MenuItemViewModel
    {

        public string PrNr { get; set; }

        public string IdNr { get; set; }

        public RelayCommand SaveCommand { get; set; }

        private readonly Credentials _cred;

        public SettingsViewModel(MainViewModel mainViewModel, Credentials cred) : base(mainViewModel)
        {
            _cred = cred;
            PrNr = _cred.PrueflingsNr;
            IdNr = _cred.IdentNr;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object arg)
        {
            _cred.PrueflingsNr = PrNr;
            _cred.IdentNr = IdNr;

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["prNr"].Value = PrNr;
            configuration.AppSettings.Settings["idNr"].Value = IdNr;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

       

    }
}
