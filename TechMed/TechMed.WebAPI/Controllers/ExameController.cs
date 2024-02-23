using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("exame")]
public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;
    private List<ExameViewModel> Exames => _exameService.GetAll();
    public ExameController(IExameService service) => _exameService = service;

    [HttpGet("exames")]
    public IActionResult Get()
    {
        try
        {
            return Ok(Exames);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("exame/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var exame = _exameService.GetById(id);
            return Ok(exame);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] NewExameInputModel exame)
    {
        _exameService.Create(exame);
        return CreatedAtAction(nameof(Get), exame);
    }

    [HttpPut("exame/{id}")]
    public IActionResult Put(int id, [FromBody] NewExameInputModel exame)
    {
        try
        {
            _exameService.Update(id, exame);
            return Ok(_exameService.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("exame/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _exameService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}