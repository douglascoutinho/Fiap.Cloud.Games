using Fiap.Cloud.Games.Domain.Entity;

namespace Fiap.Cloud.Games.Api.Models.Usuario
{
  public class PostUsuarioRequestDto
  {
    /// <summary>
    /// Nome  
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Senha
    /// </summary>
    public string? Senha { get; set; }

    /// <summary>
    /// Perfil
    /// </summary>
    public PerfilEnum Perfil { get; set; }
  }
}
