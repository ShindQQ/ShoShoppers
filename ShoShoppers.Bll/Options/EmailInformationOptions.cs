namespace ShoShoppers.Bll.Options;

/// <summary>
///     Configuration of email host and user data
/// </summary>
public sealed class EmailInformationOptions
{
    /// <summary>
    ///     Email host
    /// </summary>
    public string EmailHost { get; set; } = string.Empty;

    /// <summary>
    ///     Users email username
    /// </summary>
    public string EmailUserName { get; set; } = string.Empty;

    /// <summary>
    ///     Users email password
    /// </summary>
    public string EmailPassword { get; set; } = string.Empty;
}