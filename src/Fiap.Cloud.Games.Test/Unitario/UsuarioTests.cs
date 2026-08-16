using Fiap.Cloud.Games.Domain.Entity;
using Fiap.Cloud.Games.Domain.Services.Extensions;

namespace Fiap.Cloud.Games.Test.Unitario
{
  public class UsuarioTests
  {
    [Fact]
    public void ValidarSenhaUsuario_RetornaBoolean()
    {
      // Arrange
      var usuario = new Usuario
      (
        nome: "Douglas",
        email: "douglas.loc@hotmail.com",
        senha: "Senha@123",
        perfil: PerfilEnum.Usuario.ToString()
      );

      // Act
      var resultado = usuario.ValidarSenha();

      // Assert
      Assert.True(resultado);
    }

    [Fact]
    public void ValidarEmailUsuario_RetornaBoolean()
    {
      // Arrange
      var usuario = new Usuario
      (
        nome: "Marcio",
        email: "bastosneves@gmail.com",
        senha: "Senha@123",
        perfil: PerfilEnum.Usuario.ToString()
      );
      
      // Act
      var resultado = usuario.ValidarEmail();
      
      // Assert
      Assert.True(resultado);
    }

    [Theory]
    [InlineData("Marcio", "bastosneves@gmail.com", "Senha@123", "Usuario", true)]
    public void ValidarEmail_RetornaBoolean(string nome, string email, string senha, string perfil, bool resposta)
    {
      // Arrange
      var usuario = new Usuario
      (
        nome,
        email,
        senha,
        perfil
      );

      // Act
      var resultado = usuario.ValidarEmail();

      // Assert
      Assert.Equal(resposta, resultado);
    }
  }
}