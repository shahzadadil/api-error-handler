﻿using Basket.Framework.Logging;

namespace Basket.Framework.Error
{
    /// <summary>
    /// Error settings for the framework
    /// </summary>
    public class ErrorSettings
    {
        public MessageSettings Message { get; set; } = new MessageSettings();
        public LoggingSettings Logging { get; set; } = new LoggingSettings();
    }

    /// <summary>
    /// Settings to the response message being returned
    /// </summary>
    public class MessageSettings
    {
        public bool IncludeExceptionDetail { get; set; } = false;
    }    
}
