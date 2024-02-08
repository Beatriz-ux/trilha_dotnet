using Financa.Core.Entities;

namespace Financa.Core.Interfaces;

public interface ICategoriaCollection : IBaseCollection<Categoria>
{
   /*Categoria não terá o método de atualizar, quando uma entidade precisar 
   desse metodo deve ser colocado em sua propria interface*/
}
