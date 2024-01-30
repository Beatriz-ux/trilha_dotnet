namespace TechAdvocacia.Application.Services;
public interface IBaseService<T, X>
{
      public List<T> GetAll();
      public T? GetById(int id);
      public int Create(X objeto);
      public void Update(int id, X objeto);
      public void Delete(int id);
}
