using Basket.Framework.Error;

namespace Basket.Api.Framework
{
    public interface IApiErrorSettings
    {

    }

    public class ApiErrorSettings : ErrorSettings, IApiErrorSettings
    {
        public SerializationSettings Serialization { get; set; } = new SerializationSettings();
    }

    public class SerializationSettings
    {
        public bool UseCamelCase { get; set; } = true;
    }
}
