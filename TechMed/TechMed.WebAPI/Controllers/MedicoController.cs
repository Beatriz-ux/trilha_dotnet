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
    private List<MedicoViewModel> Medicos => _medicoService.GetAll();
    public MedicoController(IMedicoService service) => _medicoService = service;

    [HttpGet("medicos")]
    public IActionResult Get()
    {
        try
        {
            return Ok(Medicos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("medico/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var medico = _medicoService.GetById(id);
            return Ok(medico);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("medico")]
    public IActionResult Post([FromBody] NewMedicoInputModel medico)
    {
        _medicoService.Create(medico);
        return CreatedAtAction(nameof(Get), medico);
    }

    [HttpPost("medico/{id}/atendimento")]
    public IActionResult Post(int id, [FromBody] NewAtendimentoInputModel atendimento)
    {
        try
        {
            _medicoService.CreateAtendimento(id, atendimento);
            return CreatedAtAction(nameof(Get), atendimento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("medico/{id}")]
    public IActionResult Put(int id, [FromBody] NewMedicoInputModel medico)
    {
        try
        {
            _medicoService.Update(id, medico);
            return Ok(_medicoService.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("medico/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _medicoService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}