using System.Net;

namespace ShoShoppers.Bll.Models.Error;

/// <summary>
///     Custom exception for http status code
/// </summary>
public sealed class HttpStatusCodeException : Exception
{
    /// <summary>
    ///     Status code for exception
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    ///     Constructor for status code and needed message
    /// </summary>
    /// <param name="message">Message to describe error</param>
    public HttpStatusCodeException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    /// <summary>
    ///     Constructor for status code and needed message
    /// </summary>
    /// <param name="statusCode">Status code of error</param>
    /// <param name="message">Message to describe error</param>
    public HttpStatusCodeException(HttpStatusCode statusCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
