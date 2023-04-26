namespace MvcNet7.Interfaces
{
    public enum LogLevel
    {
        Error,
        Info,
        Debug,
        Warn,
        Fatal
    }
    public interface ILogRepository
    {
        bool WriteLog(string message, LogLevel level);
    }
}
