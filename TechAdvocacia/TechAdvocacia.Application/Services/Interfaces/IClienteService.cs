using System.Data.Common;
using TechAdvocacia.Application.InputModels;
namespace TechAdvocacia.Application;

public interface IClienteService 
{
    public List<ClienteViewModel> GetAll();
    public ClienteViewModel? GetById(int id);
    public int Create(NewClienteInputModel cliente);
    public void Update(int Id,NewClienteInputModel cliente);
    public void Delete(int id);
    
    

}
