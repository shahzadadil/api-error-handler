namespace Basket.Framework.Error
{
    public class ErrorSettings
    {
        public MessageSettings Message { get; set; } = new MessageSettings();
        public LoggingSettings Logging { get; set; } = new LoggingSettings();
    }

    public class MessageSettings
    {
        public bool IncludeExceptionDetail { get; set; } = false;
    }

    public class LoggingSettings
    {
        public bool LogErrors { get; set; } = false;
    }
}
