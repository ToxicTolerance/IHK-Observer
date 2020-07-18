using System.Configuration;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    class SettingsViewModel : MenuItemViewModel
    {

        public string PrNr 
        {
            get => ConfigurationManager.AppSettings.Get("prNr");
            set => ConfigurationManager.AppSettings.Set("prNr", value);
        }

        public string IdNr 
        { 
            get => ConfigurationManager.AppSettings.Get("idNr");
            set => ConfigurationManager.AppSettings.Set("idNr", value);
        }

        public RelayCommand SaveCommand { get; set; }

        public SettingsViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object arg)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["prNr"].Value = PrNr;
            configuration.AppSettings.Settings["idNr"].Value = IdNr;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

       

    }
}
