using Financa.Core.Interfaces;
using Financa.Entities;

namespace Financa.Infrastructure.Persistence;

public class DataBaseFake
{
    public ICategoriaCollection CategoriaCollection { get; } = new CategoriaDB();
    public IUsuarioCollection UsuarioCollection {get;} = new UsuarioDB();

}
