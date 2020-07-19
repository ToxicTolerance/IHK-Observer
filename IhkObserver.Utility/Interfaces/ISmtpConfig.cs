namespace IhkObserver.Utility.Interfaces
{
    public interface ISmtpConfig
    {
        string Host { get; }
        int Port { get; }
        string Mail { get; }
        string SenderPassword { get; }
    }
}
