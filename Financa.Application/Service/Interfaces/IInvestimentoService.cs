using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface IInvestimentoService
{
    List<InvestimentoViewModel> GetAll();
    InvestimentoViewModel GetById(int id);
    int Create(NewInvestimentoInputModel model);
    void Update(int id, NewInvestimentoInputModel model);
    void Delete(int id);

}
