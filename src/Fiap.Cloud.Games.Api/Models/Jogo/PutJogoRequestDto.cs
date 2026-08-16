namespace Fiap.Cloud.Games.Api.Models.Jogo
{
  public class PutJogoRequestDto
  {
    /// <summary>
    /// Descrição do Jogo
    /// </summary>
    public string? Descricao { get; set; }

    /// <summary>
    /// Ativo
    /// </summary>
    public bool Ativo { get; set; }
  }
}
