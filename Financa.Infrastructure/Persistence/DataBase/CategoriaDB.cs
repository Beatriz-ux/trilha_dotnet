using Financa.Core.Interfaces;
using Financa.Core.Entities;

namespace Financa.Infrastructure.Persistence.DataBase;

public class CategoriaDB : ICategoriaCollection
{
    private readonly List<Categoria> _categorias = new List<Categoria>();
    private int _id=0;

    public CategoriaDB()
    {
        InicializaDB();
    }

    public void InicializaDB()
    {
        Create(new Categoria { Nome = "Alimentação" });
        Create(new Categoria { Nome = "Educação" });
        Create(new Categoria { Nome = "Outros" });
    }
    public void Create(Categoria entity)
    {
        _id++;
        entity.CategoriaId = _id;
        _categorias.Add(entity);
    }

    public ICollection<Categoria> GetAll()
    {
        return _categorias;
    }

    public Categoria GetById(int id)
    {
        return _categorias.FirstOrDefault(c => c.CategoriaId == id);
    }

    public void Delete(Categoria entity)
    {
        _categorias.RemoveAll(c => c.CategoriaId == entity.CategoriaId);
    }

    


}
