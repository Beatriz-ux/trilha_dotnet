using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Infrastructure;

namespace Financa.Application.Services
{
    public class RelatorioService
    {
        private readonly AppDbContext _context;
        private readonly ICategoriaService _categoriaService;
        private readonly IContaService _contaService;
        private readonly ICustoFixoService _custoFixoService;

        public RelatorioService(AppDbContext context, ICategoriaService categoriaService, IContaService contaService, ICustoFixoService custoFixoService)
        {
            _context = context;
            _categoriaService = categoriaService;
            _contaService = contaService;
            _custoFixoService = custoFixoService;
        }

        // public ICollection<TransacoesViewModel> GetTransicoesByCategoria(int categoriaId)
        // {
        //     throw new NotImplementedException();
        // }
        public ICollection<ContaViewModel> GetContasByCustoFixoAboveLimit(double limit)
        {
            var contas = _contaService.GetAll();
            var custosFixos = _custoFixoService.GetAll();
            var contasComCustoFixoAcimaDoLimite = contas
                .Where(c => custosFixos
                    .Where(cf => cf.IdConta == c.IdConta)
                    .Sum(cf => cf.ValorFixo) > limit)
                .ToList();
            return contasComCustoFixoAcimaDoLimite;
        }
        public ICollection<ContaViewModel> GetContasByCustoVariavelAboveLimit(double limit)
        {
            var contas = _contaService.GetAll();
            var custosVariaveis = _custoVariavelService.GetAll();
            var contasComCustoVariavelAcimaDoLimite = contas
                .Where(c => custosVariaveis
                    .Where(cv => cv.IdConta == c.IdConta)
                    .Sum(cv => cv.ValorVariavel) > limit)
                .ToList();
            return contasComCustoVariavelAcimaDoLimite;
        }
        public ICollection<DateTime> GetDiasWithMoreThanXTransacoes(int x)
        {
            throw new NotImplementedException();
        }
    }
}
