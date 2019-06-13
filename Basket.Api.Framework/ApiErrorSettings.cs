using Basket.Framework.Error;

namespace Basket.Api.Framework
{
    public interface IApiErrorSettings
    {

    }

    /// <summary>
    /// Error settings or the API
    /// </summary>
    public class ApiErrorSettings : ErrorSettings, IApiErrorSettings
    {
        public SerializationSettings Serialization { get; set; } = new SerializationSettings();
    }

    /// <summary>
    /// Settings related to how the response serialisation takes place
    /// </summary>
    public class SerializationSettings
    {
        public bool UseCamelCase { get; set; } = true;
    }
}
