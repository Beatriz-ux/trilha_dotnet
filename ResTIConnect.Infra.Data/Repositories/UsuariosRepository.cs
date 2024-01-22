using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Interfaces;
using ResTIConnect.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ResTIConnect.Infra.Data.Repositories;

public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
{
    public UsuariosRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<Usuarios> Get(int id, CancellationToken cancellationToken){
        var entity = await Context.Set<Usuarios>().FirstOrDefaultAsync(x => x.UsuarioId == id, cancellationToken);
        if (entity == null){
            throw new Exception($"Entity {nameof(Usuarios)} with id {id} not found");
        }
        return entity;
    }
}
