namespace IhkObserver.Utility.Interfaces
{
    public interface IMailConfig
    {
        string SendTo { get; }
        string SendFrom { get; }
        string Subject { get; }
        bool IncludeHtml { get; }
        ISmtpConfig SmtpSetting { get; }
    }
}
