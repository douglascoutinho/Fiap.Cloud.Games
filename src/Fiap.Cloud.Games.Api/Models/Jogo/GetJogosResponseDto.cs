namespace Fiap.Cloud.Games.Api.Models.Jogo
{
  public class GetJogosResponseDto
  {
    /// <summary>
    /// Identificador do usuário
    /// </summary>
    public int Id { get; set; }

      /// <summary>
      /// Descrição do Jogo
      /// </summary>
      public string? Descricao { get; set; }

    /// <summary>
    /// Ativo
    /// </summary>
    public bool Ativo { get; set; }

    /// <summary>
    /// Data Cadastro
    /// </summary>
    public DateTime DataCadastro { get; set; }
  }
}
