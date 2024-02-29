using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
using Microsoft.AspNetCore.Authorization;
namespace Financa.WebAPI.Controller;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;
    public RelatorioController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }
    [HttpGet("transacoes-by-categoria")]
    public IActionResult GetTransicoesByCategoria([FromQuery] string categoriaNome)
    {
        var transacoes = _relatorioService.GetTransicoesByCategoria(categoriaNome);
        return Ok(transacoes);
    }
    [HttpGet("contas-by-custo-fixo-above-limit")]
    public IActionResult GetContasByCustoFixoAboveLimit([FromQuery] double limit)
    {
        var contas = _relatorioService.GetContasByCustoFixoAboveLimit(limit);
        return Ok(contas);
    }
    [HttpGet("contas-by-custo-variavel-above-limit")]
    public IActionResult GetContasByCustoVariavelAboveLimit([FromQuery] double limit)
    {
        var contas = _relatorioService.GetContasByCustoVariavelAboveLimit(limit);
        return Ok(contas);
    }
    [HttpGet("dias-with-more-than-x-transacoes")]
    public IActionResult GetDiasWithMoreThanXTransacoes([FromQuery] int x)
    {
        var dias = _relatorioService.GetDiasWithMoreThanXTransacoes(x);
        return Ok(dias);
    }
}
