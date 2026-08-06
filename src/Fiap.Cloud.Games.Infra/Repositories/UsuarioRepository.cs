using Fiap.Cloud.Games.Domain.Entity;
using Fiap.Cloud.Games.Domain.Repositories;
using Fiap.Cloud.Games.Infra.Data.EntityFramework;

namespace Fiap.Cloud.Games.Infra.Repositories
{
  public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
  {
    readonly Contexto? _contexto;

    public UsuarioRepository(Contexto? contexto) : base(contexto)
    {
      _contexto = contexto;
    }
  }
}
