namespace Fiap.Cloud.Games.Domain.Entity
{
  public abstract class EntityBase
  {
    public int Id { get;  set; }
    public bool Ativo { get;  set; }
    public DateTime DataCadastro { get; set; }
  }
}