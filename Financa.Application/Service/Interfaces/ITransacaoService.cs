using Financa.Application.ViewModels;
using Financa.Application.InputModels;

namespace Financa.Application.Services.Interfaces;

public interface ITransacaoService
{
    List<TransacaoViewModel> GetAll();
    TransacaoViewModel GetById(int id);
    int Create(NewTransacaoInputModel model);
    void Update(int id, NewTransacaoInputModel model);
    void Delete(int id);
}
