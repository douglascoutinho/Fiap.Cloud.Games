using Fiap.Cloud.Games.Domain.Entity;
using Fiap.Cloud.Games.Domain.Repositories;
using Fiap.Cloud.Games.Domain.Services.Extensions;

namespace Fiap.Cloud.Games.Domain.Services
{
  public class UsuarioService
  {
    IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
      _usuarioRepository = usuarioRepository;
    }

    public ICollection<Usuario> Buscar(bool? ativo, int offSet, int limit)
    {
      var query = _usuarioRepository.Get();

      if (ativo != null)
        query = query.Where(a => a.Ativo == ativo);

      query = query.Skip(offSet).Take(limit);

      return query.ToList();
    }

    public Usuario BuscarPorId(int id)
    {
      var usuario = _usuarioRepository.GetById(id);

      if (usuario == null)
        throw new Exception("Informado identificador que não existe.");

      return usuario;
    }

    public void Incluir(Usuario usuario)
    {
      var usuarioExistente = _usuarioRepository.GetById(usuario.Id);

      if (usuarioExistente != null)
        throw new Exception("Informado identificador já existe.");

      if (!usuario.ValidarEmail())
        throw new Exception("Email inválido.");

      _usuarioRepository.Add(usuario);

      _usuarioRepository.Commit();
    }

    public void Alterar(Usuario usuarioExistente, string? nome, string? email, string? senha, bool ativo)
    {

      if (usuarioExistente == null)
        throw new Exception("Informado identificador que não existe.");

      usuarioExistente.Atualizar
      (
          nome,
          email,
          senha,
          ativo
      );

      _usuarioRepository.Update(usuarioExistente);

      _usuarioRepository.Commit();
    }

  }
}
