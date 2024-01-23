using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Domain.Interfaces;


public interface IEventosRepository : IBaseRepository<Eventos>
{
    Task<Eventos> Get(int id, CancellationToken cancellationToken);

}
