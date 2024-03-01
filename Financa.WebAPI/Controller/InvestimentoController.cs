using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
using Microsoft.AspNetCore.Authorization;

namespace Financa.WebAPI.Controller;
[ApiController]

[Route("/api/v0.1/")]

public class InvestimentoController : ControllerBase{
    private readonly IInvestimentoService _investimentos;
    public InvestimentoController(IInvestimentoService investimentos)
    {
        _investimentos = investimentos;
    }
    [HttpGet("investimento")]
    public IActionResult Get()
    {
        try
        {
            var investimentos = _investimentos.GetAll().ToList();
            return Ok(investimentos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("{investimentoId}")]
    public IActionResult GetByInvestimentoId(int investimentoId)
    {
        try
        {
            var investimento = _investimentos.GetById(investimentoId);
            return Ok(investimento);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost("investimento")]
    public IActionResult Post([FromBody] NewInvestimentoInputModel model)
    {
        try
        {
            _investimentos.Create(model);
            if (_investimentos != null)
            {
                return Ok(model);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
        return BadRequest();
    }
    [HttpDelete("{investimentoId}")]
    public IActionResult Delete(int investimentoId)
    {
        try
        {
            
            _investimentos.Delete(investimentoId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}
// {
//     private readonly IInvestimentos _investimentos;
//     public InvestimentoController(DataBaseFake dbFake)
//     {
//         _investimentos = dbFake.InvestimentosCollection;
//     }
//     [HttpGet("investimento")]
//     public IActionResult Get()
//     {
//         try
//         {
//             var investimentos = _investimentos.GetAll().ToList();
//             return Ok(investimentos);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }
//     [HttpGet("{investimentoId}")]
//     public IActionResult GetByInvestimentoId(int investimentoId)
//     {
//         try
//         {
//             var investimento = _investimentos.GetById(investimentoId);
//             return Ok(investimento);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }
//     [HttpPost("investimento")]
//     public IActionResult Post([FromBody] Investimento model)
//     {
//         try
//         {
//             _investimentos.Create(model);
//             if (_investimentos != null)
//             {
//                 return Ok(model);
//             }
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//         return BadRequest();
//     }
//     [HttpDelete("{investimentoId}")]
//     public IActionResult Delete(int investimentoId)
//     {
//         try
//         {
//             var investimento = _investimentos.GetById(investimentoId);
//             _investimentos.Delete(investimento);
//             return Ok();
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }


// }
