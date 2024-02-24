using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface ICustoFixoService
{
    List<CustoFixoViewModel> GetAll();
    CustoFixoViewModel GetById(int id);
    int Create(NewCustoFixoInputModel model);
    void Update(int id, NewCustoFixoInputModel model);
    void Delete(int id);
}
