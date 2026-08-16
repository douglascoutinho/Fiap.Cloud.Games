namespace Fiap.Cloud.Games.Domain.Entity
{
  public class Usuario : EntityBase
  {
    public Usuario(string? nome, string? email, string? senha, string? perfil)
    {
      this.Nome = nome;
      this.Email = email;
      this.Senha = senha;
      this.Perfil = perfil;
      this.Ativo = true;
      this.DataCadastro = DateTime.Now;
    }

    public string? Nome { get; private set; }
    public string? Email { get; private set; }
    public string? Senha { get; private set; }
    public string? Perfil { get; private set; }

    internal void Atualizar(string? nome, string? email, string? senha, bool ativo)
    {
      this.Nome = nome;
      this.Email = email;
      this.Senha = senha;
      this.Ativo = ativo;
    }
  }
}
