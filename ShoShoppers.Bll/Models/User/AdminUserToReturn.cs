namespace ShoShoppers.Bll.Models.User;

/// <summary>
///     Users info in response on authentication
/// </summary>
public sealed class AdminUserToReturn
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="username">User`s name</param>
    /// <param name="token">Token</param>
    public AdminUserToReturn(string username, string token)
    {
        Username = username;
        Token = token;
    }

    /// <summary>
    ///     User`s username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     User`s token which will be returned on authentication
    /// </summary>
    public string Token { get; set; } = string.Empty;
}