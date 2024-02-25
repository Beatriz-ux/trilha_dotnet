using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Infrastructure;

namespace Financa.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;
        private readonly ICategoriaService _categoriaService;
        private readonly IContaService _contaService;
        private readonly ICustoFixoService _custoFixoService;
        private readonly ICustoVariavelService _custoVariavelService;
        private readonly ITransacaoService _transacaoService;

        public RelatorioService(AppDbContext context, ICategoriaService categoriaService, IContaService contaService, ICustoFixoService custoFixoService, ICustoVariavelService custoVariavelService, ITransacaoService transacaoService)
        {
            _context = context;
            _categoriaService = categoriaService;
            _contaService = contaService;
            _custoFixoService = custoFixoService;
            _custoVariavelService = custoVariavelService;
            _transacaoService = transacaoService;
        }

        public ICollection<TransacaoViewModel> GetTransicoesByCategoria(string categoriaNome)
        {
            var transacoes = _transacaoService.GetAll();
            var transacoesByCategoria = transacoes
                .Where(t => t.Categoria.Nome == categoriaNome)
                .ToList();
            return transacoesByCategoria;
        }
        public ICollection<ContaViewModel> GetContasByCustoFixoAboveLimit(double limit)
        {
            var contas = _contaService.GetAll();
            var custosFixos = _custoFixoService.GetAll();
            var contasComCustoFixoAcimaDoLimite = contas
                .Where(c => custosFixos
                    .Where(cf => cf.IdConta == c.IdConta)
                    .Sum(cf => cf.ValorParcelaFixo) > limit)
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
            var transacoes = _transacaoService.GetAll();
            var diasComMaisDeXTransacoes = transacoes
                .GroupBy(t => t.DataTransacao)
                .Where(g => g.Count() > x)
                .Select(g => g.Key)
                .ToList();
            return diasComMaisDeXTransacoes;
        }
    }
}
