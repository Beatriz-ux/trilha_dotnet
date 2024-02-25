using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface ICustoVariavelService
{
    List<CustoVariavelViewModel> GetAll();
    CustoVariavelViewModel GetById(int id);
    int Create(NewCustoVariavelModelInputModel model);
    void Update(int id, NewCustoVariavelModelInputModel model);
    void Delete(int id);
}
