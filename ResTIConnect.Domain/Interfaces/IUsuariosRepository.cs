using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IUsuariosRepository : IBaseRepository<Usuarios>
{
    Task<Usuarios> Get(int id, CancellationToken cancellationToken);
}
