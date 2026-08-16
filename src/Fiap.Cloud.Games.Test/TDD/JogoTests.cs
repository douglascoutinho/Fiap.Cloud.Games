using Fiap.Cloud.Games.Domain.Entity;

namespace Fiap.Cloud.Games.Test.TDD
{
  public class JogoTests
  {
    [Fact(DisplayName = "Adicionar Um Jogo Válido")]
    [Trait("Em Construção", "Jogo")]
    public void AdicionarJogo_DevePassarNaValidacao()
    {
      // Arrange
      var jogo = new Jogo("Jogo Teste", "Descrição do Jogo Teste");

      // Act
      var result = jogo.ValidarCampos();

      // Assert
      Assert.True(result);
    }
  }
}