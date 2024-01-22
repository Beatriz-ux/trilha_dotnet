using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
