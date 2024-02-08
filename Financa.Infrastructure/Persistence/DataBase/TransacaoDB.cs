using Financa.Core.Interfaces;
using Financa.Core.Entities;

namespace Financa.Infrastructure.Persistence.DataBase;

public class TransacaoDB: ITransacaoCollection
{
    private readonly List<Transacao> _transacoes = new List<Transacao>();
    private readonly List<Categoria> _categorias = new List<Categoria>();

    private readonly List<Conta> _contas = new List<Conta>();
    private int _id=0;

    public TransacaoDB( ICategoriaCollection categoriaCollection)
    {
        _categorias = categoriaCollection.GetAll().ToList();
        InicializaDB();
    }

    public void InicializaDB()
    {
        Create(new Transacao { ValorTransacao = 100, DataTransacao = DateTime.Now, TipoTransacao = "Entrada", IdConta = 1, IdCategoria = 1 });
        Create(new Transacao { ValorTransacao = 200, DataTransacao = DateTime.Now, TipoTransacao = "Saída", IdConta = 2, IdCategoria = 2 });
        Create(new Transacao { ValorTransacao = 300, DataTransacao = DateTime.Now, TipoTransacao = "Entrada", IdConta = 3, IdCategoria = 3 });
    }
    public void Create(Transacao entity)
    {
        if(_transacoes.Count == 0)
            _id = 0;
        else
            _id = _transacoes.Last().IdTransacao;
        if(_categorias.Count == 0)
            throw new Exception("Não existe essa categorias cadastradas");
        _id++;
        entity.IdTransacao = _id;
        _transacoes.Add(entity);
    }

    public ICollection<Transacao> GetAll()
    {
        return _transacoes;

}

    public Transacao GetById(int id)
    {
        return _transacoes.FirstOrDefault(c => c.IdTransacao == id);
    }

    public void Delete(Transacao entity)
    {
        _transacoes.RemoveAll(c => c.IdTransacao == entity.IdTransacao);
    }

    
}

