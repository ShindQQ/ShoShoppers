using System.Text.Json.Serialization;

namespace ShoShoppers.Bll.Models.NpModels;

/// <summary>
///     Class which will be serialized for np request
/// </summary>
public sealed class NpRequestBodyDto
{
    /// <summary>
    ///     Api key for np api
    /// </summary>
    [JsonPropertyName("apiKey")]
    public string ApiKey { get; } = string.Empty;

    /// <summary>
    ///     Name of model for request
    /// </summary>
    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;

    /// <summary>
    ///     Name of called method
    /// </summary>
    [JsonPropertyName("calledMethod")]
    public string CalledMethod { get; set; } = string.Empty;

    /// <summary>
    ///     Properties for method
    /// </summary>
    [JsonPropertyName("methodProperties")]
    public NpRequestMethodPropertiesDto? MethodProperties { get; set; }

    /// <summary>
    ///     Parameterized constructor
    /// </summary>
    /// <param name="apiKey">Api key for np api</param>
    /// <param name="modelName">Name of model for request</param>
    /// <param name="calledMethod">Method which will be called in np api</param>
    /// <param name="methodProperties">Properties for method</param>
    public NpRequestBodyDto(string apiKey, string modelName, string calledMethod, NpRequestMethodPropertiesDto? methodProperties)
    {
        ApiKey = apiKey;
        ModelName = modelName;
        CalledMethod = calledMethod;
        MethodProperties = methodProperties;
    }

    /// <summary>
    ///     Empty constructor
    /// </summary>
    public NpRequestBodyDto()
    {
    }
}
