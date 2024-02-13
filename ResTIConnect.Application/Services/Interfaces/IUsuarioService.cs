using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces;

public interface IUsuarioService
{
    public List<UsuarioViewModel> GetAll();
    public UsuarioViewModel? GetById(int id);
    public int Create(NewUsuarioInputModel usuario);
    public void Update(int id, NewUsuarioInputModel usuario);
    public void Delete(int id);

}
