using System;

namespace IhkObserver.Text.Interfaces
{
    public interface IGeneralConfig
    {
        int AzubiIdentNr { get; }
        int PrüflingsNr { get; }
        TimeSpan RepeatRunSpan { get; }
        bool NotifyOnStartup { get; }
        bool UseMailNotifications { get; }
    }
}
