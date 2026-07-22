using Fiap.Cloud.Games.Api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnet_jwt.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController(IConfiguration configuration) : ControllerBase
  {
    private readonly IConfiguration _configuration = configuration;

    /// <summary>
		/// Login
		/// </summary>
		/// <param name="dto">Corpo da requisição</param>
		/// <returns></returns>
		/// <response code="200"></response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(PostUsuarioRequestDto), 200)]
    public IActionResult Login([FromBody] PostUsuarioRequestDto dto)
    {
      if (dto.Login == "admin" && dto.Senha == "admin")
      {
        var token = GenerateToken(dto.Login, "Admin");
        return Ok(new { token });
      }
      else if (dto.Login == "user" && dto.Senha == "user")
      {
        var token = GenerateToken(dto.Login, "User");


        return Ok(new { token });
      }
      else
      {
        return Unauthorized();
      }
    }

    private string GenerateToken(string username, string role)
    {
      var claims = new[]
      {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}