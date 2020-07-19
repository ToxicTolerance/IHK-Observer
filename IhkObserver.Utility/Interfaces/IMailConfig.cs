namespace IhkObserver.Utility.Interfaces
{
    public interface IMailConfig
    {
        public string SendTo { get; }
        public string SendFrom { get; }
        public string Subject { get; }
        public bool IncludeHtml { get; }
        public ISmtpConfig SmtpSetting { get; }
    }
}
