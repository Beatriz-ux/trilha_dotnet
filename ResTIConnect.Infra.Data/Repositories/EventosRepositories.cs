using System.Data.Common;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Interfaces;
using ResTIConnect.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace ResTIConnect.Infra.Data.Repositories;
public class EventosRepositories : BaseRepository<Eventos> , IEventosRepository
{
    public EventosRepositories(AppDbContext context) : base(context)
    {
    }

    public async Task<Eventos> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<Eventos>().FirstOrDefaultAsync(x => x.EventoId == id, cancellationToken);

        if (entity == null)
        {
            throw new Exception($"Entity {nameof(Eventos)} with id {id} not found");
        }
        return entity;
    }

}
