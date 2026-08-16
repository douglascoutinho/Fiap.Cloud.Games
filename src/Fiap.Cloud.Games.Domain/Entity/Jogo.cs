namespace Fiap.Cloud.Games.Domain.Entity
{
  public class Jogo : EntityBase
  {
    public Jogo(string nome, string descricao)
    {
      Nome = nome;
      Descricao = descricao;
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }

    public bool ValidarCampos()
    {
      if (string.IsNullOrEmpty(this.Nome) || string.IsNullOrEmpty(this.Descricao))      
        throw new ApplicationException("Nome e descrição são obrigatórios");

      if (string.IsNullOrEmpty(this.Nome))     
        throw new ApplicationException("Nome é obrigatório");

      if (string.IsNullOrEmpty(this.Descricao))
        throw new ApplicationException("Descrição é obrigatória");

      if (this.Nome.Length > 50)      
        throw new ApplicationException("Nome deve ter no máximo 50 caracteres");
      
      if (this.Descricao.Length > 150)
        throw new ApplicationException("Descrição deve ter no máximo 150 caracteres");

      return true;
    }
  }
}
