using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence.DataBase;

namespace Financa.Infrastructure.Persistence;

public class DataBaseFake
{
    public ICategoriaCollection CategoriaCollection { get; } = new CategoriaDB();
    public ITransacaoCollection TransacaoCollection { get; }
    public IUsuarioCollection UsuarioCollection { get; } = new UsuarioDB();
    public IContaCollection ContaCollection { get; } = new ContaDB();

    public DataBaseFake()
    {
        // Passando uma instância de ICategoriaCollection para TransacaoDB
        TransacaoCollection = new TransacaoDB(CategoriaCollection);
    }
    public ICustoFixoCollection CustoFixoCollection { get; } = new CustoFixoDB();

    public ICustoVariavelCollection CustoVariavelCollection { get; } = new CustoVariavelDB();
    public IObjetivo ObjetivoCollection { get; } = new ObjetivoDB();
    public IInvestimentos InvestimentosCollection { get; } = new InvestimentoDB();

}
