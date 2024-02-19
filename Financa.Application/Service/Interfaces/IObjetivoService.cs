using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface IObjetivoService
{
    List<ObjetivoViewModel> GetAll();
    ObjetivoViewModel GetById(int id);
    int Create(NewObjetivoInputModel model);
    void Update(int id, NewObjetivoInputModel model);
    void Delete(int id);

}
