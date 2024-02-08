using Financa.Core.Interfaces;
using Financa.Core.Entities;

namespace Financa.Infrastructure.Persistence;

public class DataBaseFake
{
    public ICategoriaCollection CategoriaCollection { get; } = new CategoriaDB();
    public ITransacaoCollection TransacaoCollection { get; }

    public DataBaseFake()
    {
        // Passando uma instância de ICategoriaCollection para TransacaoDB
        TransacaoCollection = new TransacaoDB(CategoriaCollection);
    }

}
