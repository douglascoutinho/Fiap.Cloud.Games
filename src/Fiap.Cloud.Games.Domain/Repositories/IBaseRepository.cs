namespace Fiap.Cloud.Games.Domain.Repositories
{
  public interface IBaseRepository<TModel> : IDisposable
    where TModel : class
  {
    void Add(TModel model);
    void AddRange(ICollection<TModel> model);
    void Update(TModel model);
    void Delete(TModel model);
    List<TModel>? GetAll();
    List<TModel> GetAll(Func<TModel, bool> where);
    TModel? GetById(int id);
    TModel? Get(Func<TModel, bool> where);
    void Commit();
  }
}
