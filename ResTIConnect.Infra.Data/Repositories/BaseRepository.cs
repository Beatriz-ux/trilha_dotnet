using ResTIConnect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Domain.Entities;


namespace ResTIConnect.Infra.Data;
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;

   public BaseRepository(AppDbContext context)
   {
      Context = context;
   }
   public void Create(T entity)
   {
     // entity.DateCreated = DateTimeOffset.UtcNow;
      Context.Add(entity);
   }
   public void Update(T entity)
   {
     // entity.DateUpdated = DateTimeOffset.UtcNow;
      Context.Update(entity);
   }

   public void Delete(T entity)
   {
     // entity.DateDeleted = DateTimeOffset.UtcNow;
      Context.Remove(entity);
   }

//    public async Task<T> Get(Guid id, CancellationToken cancellationToken)
//    {
//       var entity = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

//       if (entity == null)
//       {
//          throw new Exception($"Entity {nameof(T)} with id {id} not found");
//       }
//       return entity;
//    }
// como cada entidade tem seu proprio nome de id , não precisa mais do metodo acima
   public async Task<List<T>> GetAll(CancellationToken cancellationToken)
   {
      return await Context.Set<T>().ToListAsync(cancellationToken);
   }

}
