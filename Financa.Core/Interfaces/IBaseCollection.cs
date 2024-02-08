namespace Financa.Core.Interfaces;

public interface IBaseCollection<T>
{
    void Create(T entity);
    ICollection<T> GetAll();
    T GetById(int id);
    void Delete(T entity);


}
