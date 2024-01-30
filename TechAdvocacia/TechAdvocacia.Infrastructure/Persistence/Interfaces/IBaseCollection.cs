namespace TechAdvocacia.Infrastructure.Persistence.Interfaces;

public interface IBaseCollection<T>
{
    int Create(T obj);
    void Update(T obj , int id);
    void Delete(int id);
    T? GetById(int id);
    ICollection<T> GetAll();

}
