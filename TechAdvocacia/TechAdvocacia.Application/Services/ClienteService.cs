using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence;
namespace TechAdvocacia.Application.Services;

public class ClienteService : IClienteService
{
    private readonly TechAdvocaciaDbContext _dbContext;

    public ClienteService(TechAdvocaciaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = new Cliente{
            
            Nome = cliente.Nome
        };
        _dbContext.Clientes.Add(_cliente);
        _dbContext.SaveChanges();

        return _cliente.ClienteId;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<ClienteViewModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public ClienteViewModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int Id, NewClienteInputModel cliente)
    {
        throw new NotImplementedException();
    }
}
