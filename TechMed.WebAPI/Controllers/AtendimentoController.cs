using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("atendimento")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;
    public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
    public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;

    [HttpGet("atendimentos")]
    public IActionResult Get()
    {
        return Ok(Atendimentos);
    }

    [HttpGet("atendimento/{id}")]
    public IActionResult GetById(int id)
    {
        try{
            var atendimento = _atendimentoService.GetById(id);
            return Ok(atendimento);
        } catch (Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] AtendimentoInputModel atendimento)
    {
        _atendimentoService.Create(atendimento);
        return CreatedAtAction(nameof(Get), atendimento);
    }

    [HttpPut("atendimento/{id}")]
    public IActionResult Put(int id, [FromBody] AtendimentoInputModel atendimento)
    {
        if(_atendimentoService.GetById(id) == null) return NoContent();
        _atendimentoService.Update(id, atendimento);
        return Ok(_atendimentoService.GetById(id));
    }

    [HttpDelete("atendimento/{id}")]
    public IActionResult Delete(int id)
    {
        if(_atendimentoService.GetById(id) == null) return NoContent();
        _atendimentoService.Delete(id);
        return Ok();
    }
}
