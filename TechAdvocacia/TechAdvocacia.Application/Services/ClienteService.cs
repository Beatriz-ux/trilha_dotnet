using TechAdvocacia.Application.InputModels;

namespace TechAdvocacia.Application.Services;

public class ClienteService : IClienteService
{
    private readonly TechAdvocaciaDbContext _dbContext;
    public int Create(NewClienteInputModel cliente)
    {
        throw new NotImplementedException();
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
