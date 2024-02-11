using Financa.Core.Entities;
using Financa.Core.Interfaces;

namespace Financa.Infrastructure;

public class ObjetivoDB : IObjetivo
{
    private readonly List<Objetivo> _objetivos = new List<Objetivo>();
    private int _id = 0;

    public ObjetivoDB()
    {
        InicializaDB();
    }

    public void InicializaDB()
    {
        // Criar objetivos
        Objetivo objetivoCarro = new Objetivo { Nome = "Comprar um carro" };
        Objetivo objetivoCasa = new Objetivo { Nome = "Comprar uma casa" };
        Objetivo objetivoViagem = new Objetivo { Nome = "Viajar" };

        // Adicionar investimentos aos objetivos
        objetivoCarro.Investimentos = new List<Investimento>{
        new Investimento { Nome = "IRenda Fixa" },
        };

        objetivoCasa.Investimentos = new List<Investimento>
    {
        new Investimento { Nome = "IBOVESPA" },
        new Investimento { Nome = "CAIXAF2" }
    };

        objetivoViagem.Investimentos = new List<Investimento>
    {
        new Investimento { Nome = "Investimento Viagem 1" },
        new Investimento { Nome = "Investimento Viagem 2" }
    };

        // Adicionar os objetivos com investimentos ao banco de dados
        Create(objetivoCarro);
        Create(objetivoCasa);
        Create(objetivoViagem);
    }

    public void Create(Objetivo entity)
    {
        _id++;
        entity.Id = _id;
        _objetivos.Add(entity);
    }

    public ICollection<Objetivo> GetAll()
    {
        return _objetivos;
    }

    public Objetivo GetById(int id)
    {
        return _objetivos.FirstOrDefault(c => c.Id == id);
    }

    public void Delete(Objetivo entity)
    {
        _objetivos.RemoveAll(c => c.Id == entity.Id);
    }

}
