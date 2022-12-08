namespace ShoShoppers.Bll.Models.User;

/// <summary>
///     User with access to react-admin
/// </summary>
public sealed class AdminUser
{
    /// <summary>
    /// </summary>
    /// <param name="username">User`s name</param>
    /// <param name="password">User`s password</param>
    public AdminUser(string username, string password)
    {
        Username = username;
        Password = password;
    }

    /// <summary>
    ///     User`s username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     User`s password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}