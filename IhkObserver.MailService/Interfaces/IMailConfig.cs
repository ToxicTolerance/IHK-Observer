namespace IhkObserver.MailService.Interfaces
{
    public interface IMailConfig
    {
        public string SendTo { get; }
        public string Subject { get; }
        public bool IncludeHtml { get; }
    }
}
