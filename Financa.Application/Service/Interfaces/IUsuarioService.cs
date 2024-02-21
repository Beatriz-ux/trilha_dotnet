using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface IUsuarioService
{
    List<UsuarioViewModel> GetAll();
    UsuarioViewModel GetById(int id);
    int Create(NewUsuarioInputModel usuario);
    void Update(int id, NewUsuarioInputModel usuario);
    void Delete(int id);

}
