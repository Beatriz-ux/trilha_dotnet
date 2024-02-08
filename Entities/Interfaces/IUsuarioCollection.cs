using Entities;
using Financa.Entities;

namespace Financa.Core.Interfaces;

public interface IUsuarioCollection : IBaseCollection<Usuario>
{
    /* void Create(Usuario entity);
    ICollection<Usuario> GetAll();
    Usuario GetById(int id);
    void Delete(Usuario entity); */
    void Update(Usuario entity);

}
