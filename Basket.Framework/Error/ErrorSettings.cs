namespace Basket.Framework.Error
{
    public class ErrorSettings
    {
        public MessageSettings Message => new MessageSettings();
        public LoggingSettings Logging => new LoggingSettings();
    }

    public class MessageSettings
    {
        public bool IncludeExceptionDetail => false;
    }

    public class LoggingSettings
    {
        public bool LogErrors => false;
    }
}
