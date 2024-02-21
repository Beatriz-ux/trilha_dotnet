using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Financa.Application.InputModels;

namespace Financa.WebAPI.Controller;
[ApiController]
[Route("/api/v0.1/")]
public class ContaController : ControllerBase
{
    private readonly IContaService _contaService;

    public ContaController(IContaService contaService)
    {
        _contaService = contaService;
    }

    [HttpGet("contas")]
    public IActionResult GetAll()
    {
        try
        {
            var contas = _contaService.GetAll().ToList();
            return Ok(contas);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("contas/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var objetivo = _contaService.GetById(id);
            return Ok(objetivo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost("contas")]
    public IActionResult Post([FromBody] NewContaInputModel model)
    {
        try
        {
            _contaService.Create(model);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPut("contas/{id}")]
    public IActionResult Update(int id, NewContaInputModel conta)
    {
        try
        {
            _contaService.Update(id, conta);
            return Ok(conta);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpDelete("{contaId}")]
    public IActionResult Delete(int contaId)
    {
        try
        {
            _contaService.Delete(contaId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    // [HttpGet("conta")]
    // public IActionResult Get()
    // {
    //     try
    //     {
    //         var contas = _conta.GetAll().ToList();
    //         return Ok(contas);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Erro: {ex.Message}");
    //     }
    // }

    // [HttpGet("{contaId}")]
    // public IActionResult GetByContaId(int contaId)
    // {
    //     try
    //     {
    //         var conta = _conta.GetById(contaId);
    //         return Ok(conta);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Erro: {ex.Message}");
    //     }
    // }

    // [HttpPost("conta")]
    // public IActionResult Post([FromBody] Conta model)
    // {
    //     try
    //     {
    //         _conta.Create(model);

    //         if (_conta != null)
    //         {
    //             return Ok(model);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Erro: {ex.Message}");
    //     }
    //     return BadRequest();
    // }

    // [HttpDelete("{contaId}")]
    // public IActionResult Delete(int contaId)
    // {
    //     try
    //     {
    //         var conta = _conta.GetById(contaId);
    //         if(conta != null)
    //         {
    //             _conta.Delete(conta);
    //             return Ok();
    //         }
    //         return BadRequest("Conta não encontrada");
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Erro: {ex.Message}");
    //     }
    // }
}
