using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
namespace TechAdvocacia.Application.Services;
public interface IBaseService<T>
{
      public List<T> GetAll();
      public T? GetById(int id);
      public int Create(T objeto);
      public void Update(int id, T objeto);
      public void Delete(int id);
}
