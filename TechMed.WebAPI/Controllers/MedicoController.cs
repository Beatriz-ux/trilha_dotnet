using Microsoft.AspNetCore.Mvc;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("medico")]
public class MedicoController : ControllerBase
{
    private readonly IMedicoService _medicoService;
    public List<MedicoViewModel> Medicos => _medicoService.GerAll();
    public MedicoController(IMedicoService service) => _medicoService = service;

    [HttpGet("medicos")]
    public IActionResult Get()
    {
        return Ok(Medicos);
    }

    [HttpGet("medico/{id}")]
    public IActionResult GetById(int id)
    {
        try{
            var medico = _medicoService.GetById(id);
            return Ok(medico);
        } catch (Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpPost("medico")]
    public IActionResult Post([FromBody] MedicoInputModel medico)
    {
        _medicoService.Create(medico);
        return CreatedAtAction(nameof(Get), medico);
    }

    [HttpPost("medico/{id}/atendimento")]
    public IActionResult Post(int id, [FromBody] AtendimentoInputModel atendimento)
    {
        _medicoService.CreateAtendimento(id, atendimento);
        return CreatedAtAction(nameof(Get), atendimento);
    }

    [HttpPut("medico/{id}")]
    public IActionResult Put(int id, [FromBody] MedicoInputModel medico)
    {
        if(_medicoService.GetById(id) == null) return NoContent();
        _medicoService.Update(id, medico);
        return Ok(_medicoService.GetById(id));
    }

    [HttpDelete("medico/{id}")]
    public IActionResult Delete(int id)
    {
        if(_medicoService.GetById(id) == null) return NoContent();
        _medicoService.Delete(id);
        return Ok();
    }
}
