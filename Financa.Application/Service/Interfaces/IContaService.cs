using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface IContaService
{
    List<ContaViewModel> GetAll();
    ContaViewModel GetById(int id);
    int Create(NewContaInputModel model);
    void Update(int id, NewContaInputModel model);
    void Delete(int id);
}
