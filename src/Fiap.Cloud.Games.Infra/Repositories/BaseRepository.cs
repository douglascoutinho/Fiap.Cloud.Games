using Fiap.Cloud.Games.Domain.Repositories;
using Fiap.Cloud.Games.Infra.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Cloud.Games.Infra.Repositories
{
  /// <summary>
  /// Repositorio base 
  /// </summary>
  public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
    where TModel : class
  {
    private readonly Contexto? _contexto;
    protected BaseRepository(Contexto? context) =>  _contexto = context;
    public virtual void Add(TModel model) => _contexto?.Add(model);
    public virtual void AddRange(ICollection<TModel> model) => _contexto?.AddRange(model);
    public virtual void Update(TModel model) =>  _contexto?.Update(model);
    public virtual void Delete(TModel model) =>  _contexto?.Remove(model);
    public virtual List<TModel>? GetAll() => _contexto?.Set<TModel>()?.ToList();
    public virtual TModel? GetById(int id) => _contexto?.Set<TModel>().Find(id);
    public virtual List<TModel> GetAll(Func<TModel, bool> where) => _contexto.Set<TModel>().AsNoTracking().Where(where).ToList();
    public virtual TModel? Get(Func<TModel, bool> where) => _contexto?.Set<TModel>().AsNoTracking().FirstOrDefault(where);
    public void Commit() => _contexto?.SaveChanges();
    public virtual void Dispose() => _contexto?.Dispose();
  }
}
