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
        _dbContext.Clientes.Remove(_dbContext.Clientes.Find(id));
    }

    public List<ClienteViewModel> GetAll()
    {
        var _clientes = _dbContext.Clientes.ToList();
        var _clientesViewModel = new List<ClienteViewModel>();
        foreach (var _cliente in _clientes)
        {
            var _clienteViewModel = new ClienteViewModel{
                ClienteId = _cliente.ClienteId,
                Nome = _cliente.Nome
            };
            _clientesViewModel.Add(_clienteViewModel);
        }
        return _clientesViewModel;
        
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = _dbContext.Clientes.Find(id);
        if(_cliente == null) return null;
        var _clienteViewModel = new ClienteViewModel{
            ClienteId = _cliente.ClienteId,
            Nome = _cliente.Nome
        };
        return _clienteViewModel;
    }

    public void Update(int Id, NewClienteInputModel cliente)
    {
        var _cliente = _dbContext.Clientes.Find(Id);
        if(_cliente == null) return;
        _cliente.Nome = cliente.Nome;
        _dbContext.SaveChanges();
        

    }
}
