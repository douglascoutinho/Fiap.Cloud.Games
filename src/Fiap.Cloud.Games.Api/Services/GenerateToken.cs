using Fiap.Cloud.Games.Domain.Entity;
using Fiap.Cloud.Games.Domain.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Cloud.Games.Api.Services
{
  public class GenerateToken : IGenerateToken
  {
    public string Autenticar(Usuario usuario, string jwtKey, string jwtIssuer)
    {
      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
        new Claim(ClaimTypes.Role, usuario.Perfil),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken
      (
        issuer: jwtIssuer,
        claims: claims,
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}