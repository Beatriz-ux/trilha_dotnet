using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface ICategoriaService
{
    List<CategoriaViewModel> GetAll();
    CategoriaViewModel GetById(int id);
    int Create(NewCategoriaInputModel newCategoria);
    void Update(int id, NewCategoriaInputModel newCategoria);

    void Delete(int id);

}
