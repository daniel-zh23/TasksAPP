using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TasksAPI.Core.Contracts;
using TasksAPI.Core.Models;
using TasksAPI.Database.Data.Models.Account;

namespace TasksAPI.Core.Services;

public class TokenService : ITokenService
{
    public LoginResultModel LoginUser(ApplicationUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(15);
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("secretKeyVeRyMuCh")
            ),
            SecurityAlgorithms.HmacSha256
        );
        
        var token = new JwtSecurityToken(
            "TasksAPI",
            "TasksAPI",
            CreateClaims(user),
            expires: expiration,
            signingCredentials: signingCredentials
            
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return new LoginResultModel
        {
            Email = user.Email,
            Token = tokenHandler.WriteToken(token)
        };
    }

    private IEnumerable<Claim> CreateClaims(ApplicationUser user)
    {
        return new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
        };
    }
}