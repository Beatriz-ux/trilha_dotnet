using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Financa.WebAPI.Controller;

public class ContaController : ControllerBase
{
    private readonly IContaCollection _conta;

    public ContaController(DataBaseFake dbFake)
    {
        _conta = dbFake.ContaCollection;
    }

    [HttpGet("conta")]
    public IActionResult Get()
    {
        try
        {
            var contas = _conta.GetAll().ToList();
            return Ok(contas);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{contaId}")]
    public IActionResult GetByContaId(int contaId)
    {
        try
        {
            var conta = _conta.GetById(contaId);
            return Ok(conta);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost("conta")]
    public IActionResult Post([FromBody] Conta model)
    {
        try
        {
            _conta.Create(model);

            if (_conta != null)
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

    [HttpDelete("{contaId}")]
    public IActionResult Delete(int contaId)
    {
        try
        {
            var conta = _conta.GetById(contaId);
            if(conta != null)
            {
                _conta.Delete(conta);
                return Ok();
            }
            return BadRequest("Conta não encontrada");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}
