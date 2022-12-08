namespace ShoShoppers.Api.Options;

/// <summary>
///     Configuration of admin`s data for authorization
/// </summary>
public sealed class AdminInfoOptions
{
    /// <summary>
    ///     Username of admin
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Password of admin
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    ///     Secret for key
    /// </summary>
    public string SecretForKey { get; set; } = string.Empty;
}