using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("paciente")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    private List<PacienteViewModel> Pacientes => _pacienteService.GetAll();
    public PacienteController(IPacienteService pacienteService) => _pacienteService = pacienteService;

    [HttpGet("pacientes")]
    public IActionResult Get()
    {
        try
        {
            return Ok(Pacientes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("paciente/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var paciente = _pacienteService.GetById(id);
            return Ok(paciente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("paciente")]
    public IActionResult Post([FromBody] NewPacienteInputModel paciente)
    {
        _pacienteService.Create(paciente);
        return CreatedAtAction(nameof(Get), paciente);
    }

    [HttpPut("paciente/{id}")]
    public IActionResult Put(int id, [FromBody] NewPacienteInputModel paciente)
    {
        try
        {
            _pacienteService.Update(id, paciente);
            return Ok(_pacienteService.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("paciente/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _pacienteService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}