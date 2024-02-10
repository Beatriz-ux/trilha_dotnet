using Financa.Core.Entities;
using Financa.Core.Interfaces;

namespace Financa.Infrastructure.Persistence.DataBase;

public class ContaDB : IContaCollection
{
    private readonly List<Conta> _contas = new List<Conta>();
    private int _id = 0;
    public ContaDB()
    {
        InicializaDB();
    }
    public void InicializaDB()
    {
        Create(new Conta { TipoConta = "Conta Corrente", SaldoConta = 1000 });
        Create(new Conta { TipoConta = "Conta Poupança", SaldoConta = 500 });
    }
    public void Create(Conta entity)
    {
        _id++;
        entity.IdConta = _id;
        _contas.Add(entity);
    }
    public ICollection<Conta> GetAll()
    {
        return _contas;
    }
    public Conta GetById(int id)
    {
        return _contas.FirstOrDefault(c => c.IdConta == id);
    }
    public void Delete(Conta entity)
    {
        _contas.RemoveAll(c => c.IdConta == entity.IdConta);
    }
}
