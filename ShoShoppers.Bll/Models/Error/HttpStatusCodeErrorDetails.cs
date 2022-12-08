using Newtonsoft.Json;

namespace ShoShoppers.Bll.Models.Error;

/// <summary>
///     Class which describes info about status code and message of error
/// </summary>
public sealed class HttpStatusCodeErrorDetails
{
    /// <summary>
    ///     Http status code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    ///     Message of error
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Constructor for details of http status code errors
    /// </summary>
    /// <param name="statusCode">Status code</param>
    /// <param name="message">Message describing error</param>
    public HttpStatusCodeErrorDetails(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    /// <summary>
    ///     Serializing object
    /// </summary>
    /// <returns>Serialized object</returns>
    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }
}
