using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces;

public interface IEnderecoService
{
    public List<EnderecoViewModel> GetAll();
    public EnderecoViewModel? GetById(int id);
    public int Create(NewEnderecoInputModel endereco);
    public void Update(int id, NewEnderecoInputModel endereco);
    public void Delete(int id);

}
