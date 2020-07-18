namespace IhkObserver.MailService.Interfaces
{
    public interface ISmtpConfig
    {
        public string Host { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }
    }
}
