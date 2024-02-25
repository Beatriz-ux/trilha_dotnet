using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("atendimento")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;
    public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;
    private List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();

    [HttpGet("atendimentos")]
    public IActionResult Get()
    {
        try
        {
            return Ok(Atendimentos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("atendimento/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var atendimento = _atendimentoService.GetById(id);
            return Ok(atendimento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
    {
        _atendimentoService.Create(atendimento);
        return CreatedAtAction(nameof(Get), atendimento);
    }

    [HttpPut("atendimento/{id}")]
    public IActionResult Put(int id, [FromBody] NewAtendimentoInputModel atendimento)
    {
        try
        {
            _atendimentoService.Update(id, atendimento);
            return Ok(_atendimentoService.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("atendimento/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _atendimentoService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}