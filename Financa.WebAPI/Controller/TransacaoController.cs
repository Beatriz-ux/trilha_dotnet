using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
namespace Financa.WebAPI.Controller;

[ApiController]
[Route("/api/v0.1/")]
public class TransacaoController: ControllerBase
{
    private readonly ITransacaoCollection _transacao;

    public TransacaoController(DataBaseFake dbFake)
    {
        _transacao = dbFake.TransacaoCollection;
    }

     [HttpGet ("transacao")]
    public IActionResult Get()
    {
        try
        {
            var transacoes = _transacao.GetAll().ToList();
            return Ok(transacoes);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{transacaoId}")]
    public IActionResult GetById(int id){
        return Ok(_transacao.GetById(id));
    }

    [HttpPost ("transacao")]
    public IActionResult Post([FromBody] Transacao transacao){
        try
        {
            _transacao.Create(transacao);
            return Ok(transacao);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpDelete("{transacaoId}")]
    public IActionResult Delete(int transacaoId){
        try
        {
            var transacao = _transacao.GetById(transacaoId);
            if (transacao != null)
            {
                _transacao.Delete(transacao);
                return Ok();
            }

            return BadRequest("transacao não encontrada");
        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }



   



}
