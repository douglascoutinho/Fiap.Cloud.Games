using Fiap.Cloud.Games.Domain.Entity;

namespace Fiap.Cloud.Games.Domain.Services.Interface
{
  public interface IGenerateToken
  {
    string Autenticar(Usuario usuario, string? Key, string? issuer);
  }
}