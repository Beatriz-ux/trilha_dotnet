using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence.Interfaces;
namespace TechAdvocacia.Infrastructure.Persistence;

public class ClienteDB : ICliente
{
    private readonly List<Cliente> _clientes = new List<Cliente>();
    private int _id=1;

    public int Create(Cliente cliente)
    {
        if (_clientes.Count > 0)
        {
            _id = _clientes.Max(x => x.ClienteId);
        }
        cliente.ClienteId = _id++;
        cliente.Nome = cliente.Nome;
        _clientes.Add(cliente);

        return cliente.ClienteId;


    }

    public void Delete(int id)
    {
        _clientes.RemoveAll(x => x.ClienteId == id);
    }

    public ICollection<Cliente> GetAll()
    {
        return _clientes.ToArray();
    }

    public Cliente? GetById(int id)
    {
        return _clientes.FirstOrDefault(x => x.ClienteId == id);
    }

    public void Update(Cliente cliente, int id)
    {
        var novoCliente = _clientes.FirstOrDefault(x => x.ClienteId == id);
        if(novoCliente is not null)
        novoCliente.Nome = cliente.Nome;
    }
}
