using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Financa.WebAPI.Controller;

[ApiController]
[Authorize]
[Route("/api/v0.1/")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    [HttpGet("transacoes")]
    public IActionResult GetAll()
    {
        try
        {
            var transacoes = _transacaoService.GetAll();
            return Ok(transacoes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("transacoes/{id}")]
    public IActionResult GetById(int id)
    {
        try{
            var transacao = _transacaoService.GetById(id);
            return Ok(transacao);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }

    [HttpPost("transacoes")]
    public IActionResult Create(NewTransacaoInputModel transacao)
    {
        try{
            _transacaoService.Create(transacao);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok(transacao);
    }

    [HttpPut("transacoes/{id}")]
    public IActionResult Update(int id, NewTransacaoInputModel transacao)
    {
        try{
            _transacaoService.Update(id, transacao);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok(transacao);
    }
}
