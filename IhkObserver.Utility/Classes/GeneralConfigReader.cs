using IhkObserver.Utility.Exceptions;
using IhkObserver.Utility.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace IhkObserver.Utility.Classes
{
    public class GeneralConfigReader : BaseConfigReader, IGeneralConfigReader
    {
        public async Task<IGeneralConfig> ReadAsync()
        {
            string json = await ReadAsync(ConfigPath + "GeneralConfig.json");

            try
            {
                GeneralConfig config = JsonSerializer.Deserialize<GeneralConfig>(json);
                config.SetRepeatRunSpan();
                return config;
            }
            catch (Exception ex)
            {
                throw new ConfigUnparsableException("GeneralConfig.json could not be parsed!", ex);
            }
        }

        private class GeneralConfig : IGeneralConfig
        {
            public void SetRepeatRunSpan()
            {
                switch (TimeUnit.ToUpperInvariant())
                {
                    case "MILLISECOND":
                    case "MILLISECONDS":
                        RepeatRunSpan = TimeSpan.FromMilliseconds(RepeatRunEach);
                        break;
                    case "SECOND":
                    case "SECONDS":
                        RepeatRunSpan = TimeSpan.FromSeconds(RepeatRunEach);
                        break;
                    case "MINUTE":
                    case "MINUTES":
                        RepeatRunSpan = TimeSpan.FromMinutes(RepeatRunEach);
                        break;
                    case "HOUR":
                    case "HOURS":
                        RepeatRunSpan = TimeSpan.FromHours(RepeatRunEach);
                        break;
                    case "DAY":
                    case "DAYS":
                        RepeatRunSpan = TimeSpan.FromDays(RepeatRunEach);
                        break;
                    default:
                        RepeatRunSpan = TimeSpan.FromMinutes(RepeatRunEach);
                        break;
                }
            }

            public int AzubiIdentNr { get; set; }
            public int PrüflingsNr { get; set; }
            public int RepeatRunEach { get; set; }
            public string TimeUnit { get; set; }
            public bool NotifyOnStartup { get; set; }
            public bool UseMailNotifications { get; set; }
            public TimeSpan RepeatRunSpan { get; private set; }
        }
    }
}
