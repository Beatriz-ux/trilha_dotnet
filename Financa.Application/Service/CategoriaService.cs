using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;

namespace Financa.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _dbContext;

    public CategoriaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Create(NewCategoriaInputModel newCategoria)
    {
        var categoria = new Categoria{
            Nome = newCategoria.Nome
        };
        _dbContext.Categorias.Add(categoria);
        _dbContext.SaveChanges();
        return categoria.CategoriaId;
    }

    public void Delete(int id)
    {
        var categoria = _dbContext.Categorias.Find(id);
        _dbContext.Categorias.Remove(categoria);
        _dbContext.SaveChanges();
        
    }

    public List<CategoriaViewModel> GetAll()
    {
        var categorias = _dbContext.Categorias
            .Select(c => new CategoriaViewModel{
                Nome = c.Nome
            })
            .ToList();
        return categorias;
    }

    public CategoriaViewModel GetById(int id)
    {
        var categoria = _dbContext.Categorias
            .Where(c => c.CategoriaId == id)
            .Select(c => new CategoriaViewModel{
                Nome = c.Nome
            })
            .FirstOrDefault();
        if (categoria == null)
        {
            throw new Exception("Categoria não encontrada");
        }
        return categoria;
    }

    public void Update(int id, NewCategoriaInputModel newCategoria)
    {
        var categoria = _dbContext.Categorias.Find(id);
        if (categoria == null)
        {
            throw new Exception("Categoria não encontrada");
        }
        categoria.Nome = newCategoria.Nome;
        _dbContext.SaveChanges();
    }

}
