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

        // Transições por categoria (Não tem transição ainda)
        // Contas com custo fixo maior que um valor x (Não tem custo fixo ainda)
        // Contas com custo variavel maior que um valor x (Não tem custo fixo ainda)
        // Dias que tiveram mais de X transações (Não tem transação ainda)

        public ICollection<TransacoesViewModel> GetTransicoesByCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }
        public ICollection<ContaViewModel> GetContasByCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }
        public ICollection<ContaViewModel> GetContasByCustoFixoAboveLimit(double limit)
        {
            throw new NotImplementedException();
        }
        public ICollection<ContaViewModel> GetContasByCustoVariavelAboveLimit(double limit)
        {
            throw new NotImplementedException();
        }
    }
}
