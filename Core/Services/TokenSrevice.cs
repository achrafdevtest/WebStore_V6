using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;
public class TokenSrevice : ITokenService
{
    private readonly IConfiguration _config;

    private readonly SymmetricSecurityKey _key;
    public TokenSrevice(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));

    }

    public string GenerateToken(AppUser user)
    {
        var claims = new List<Claim>
       {
           new Claim(JwtRegisteredClaimNames.Email,user.Email),
           new Claim(JwtRegisteredClaimNames.GivenName,user.DisplayName),
       };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _config["Token:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
