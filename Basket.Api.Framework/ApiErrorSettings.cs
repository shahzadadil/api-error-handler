using Basket.Framework.Error;

namespace Basket.Api.Framework
{
    public class ApiErrorSettings : ErrorSettings
    {
        public SerializationSettings Serialization { get; set; } = new SerializationSettings();
    }

    public class SerializationSettings
    {
        public bool UseCamelCase { get; set; } = true;
    }
}
