using Financa.Core.Entities;
using Financa.Core.Interfaces;

namespace Financa.Infrastructure;

public class InvestimentoDB : IInvestimentos
{
    private readonly List<Investimento> _investimentos = new List<Investimento>();
    private int _id = 0;

    public InvestimentoDB()
    {
        InicializaDB();
    }

    public void InicializaDB()
    {
        // // Criar investimentos
        // Investimento investimento1 = new Investimento { Nome = "IRenda Fixa" };
        // Investimento investimento2 = new Investimento { Nome = "IBOVESPA" };
        // Investimento investimento3 = new Investimento { Nome = "CAIXAF2" };
        // Investimento investimento4 = new Investimento { Nome = "Investimento Viagem 1" };
        // Investimento investimento5 = new Investimento { Nome = "Investimento Viagem 2" };

        // // Adicionar os investimentos ao banco de dados
        // Create(investimento1);
        // Create(investimento2);
        // Create(investimento3);
        // Create(investimento4);
        // Create(investimento5);
    }

    public void Create(Investimento entity)
    {
        _id++;
        entity.IdInvestimento = _id;
        _investimentos.Add(entity);
    }

    public ICollection<Investimento> GetAll()
    {
        return _investimentos;
    }

    public Investimento GetById(int id)
    {
        return _investimentos.FirstOrDefault(c => c.IdInvestimento == id);
    }

    public void Update(Investimento entity)
    {
        var investimento = GetById(entity.IdInvestimento);
        investimento.Nome = entity.Nome;
        investimento.ValorInvestido = entity.ValorInvestido;
        investimento.DataCompra = entity.DataCompra;
        investimento.TaxaDeRetorno = entity.TaxaDeRetorno;
        investimento.IdConta = entity.IdConta;
    }

    public void Delete(Investimento entity)
    {
        _investimentos.Remove(entity);
    }

}
