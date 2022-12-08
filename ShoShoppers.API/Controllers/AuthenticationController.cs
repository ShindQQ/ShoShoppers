using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoShoppers.Api.Options;
using ShoShoppers.Bll.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoShoppers.Api.Controllers;

/// <summary>
///     Controller for authentication
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    ///     Class which represents users admin data
    /// </summary>
    private readonly AdminInfoOptions _options;

    /// <summary>
    ///     Authentication constructor
    /// </summary>
    /// <param name="options">Information about admin user</param>
    public AuthenticationController(IOptions<AdminInfoOptions> options)
    {
        _options = options.Value;
    }

    /// <summary>
    ///     Authentication
    /// </summary>
    /// <param name="user">User which contains password and username</param>
    /// <returns>Authenticated admin for react-admin</returns>
    /// <status code="200">Succesfully authorized</status>
    /// <status code="401">Unathorized</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Produces("application/json")]
    public IActionResult Authenticate(AdminUser user)
    {
        if (!user.Username.Equals(_options.Username) && !user.Password.Equals(_options.Password)) return Unauthorized();

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>
        {
            new("username", user.Username),
            new("password", user.Password)
        };

        var jwtSecurityToken = new JwtSecurityToken(claims: claimsForToken, expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials);

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        var userToReturn = new AdminUserToReturn(user.Username, tokenToReturn);

        return Ok(userToReturn);
    }
}