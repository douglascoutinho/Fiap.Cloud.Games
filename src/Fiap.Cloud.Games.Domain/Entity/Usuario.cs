namespace Fiap.Cloud.Games.Domain.Entity
{
  public class Usuario : EntityBase
  {
    public string? Nome { get; private set; }
    public string? Email { get; private set; }
  }
}
