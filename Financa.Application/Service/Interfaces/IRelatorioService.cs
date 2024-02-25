using Financa.Application.InputModels;
using Financa.Application.ViewModels;

namespace Financa.Application.Services.Interfaces;

public interface IRelatorioService
{
    ICollection<TransacaoViewModel> GetTransicoesByCategoria(string categoriaNome);
    ICollection<ContaViewModel> GetContasByCustoFixoAboveLimit(double limit);
    ICollection<ContaViewModel> GetContasByCustoVariavelAboveLimit(double limit);
    ICollection<DateTime> GetDiasWithMoreThanXTransacoes(int x);
}
