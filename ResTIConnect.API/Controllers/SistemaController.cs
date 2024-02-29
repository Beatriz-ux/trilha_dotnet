using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.API.Controllers;
[ApiController]

[Authorize]

public class SistemaController : ControllerBase
{
    private readonly ISistemaService _sistemaService;
    public List<SistemaViewModel> Sistemas => _sistemaService.GetAll();

    public SistemaController(ISistemaService sistemaService)
    {
        _sistemaService = sistemaService;
    }

    [HttpGet("/api/sistemas")]
    public IActionResult Get()
    {
        return Ok(Sistemas);
    }

    [HttpGet("/api/sistemas/{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var sistema = _sistemaService.GetById(id);
            return Ok(sistema);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/api/sistemas")]
    public IActionResult Post([FromBody] NewSistemaInputModel sistema)
    {
        _sistemaService.Create(sistema);
        return CreatedAtAction(nameof(Get), sistema);
    }

    [HttpPut("/api/sistemas/{id}")]
    public IActionResult Put(int id, [FromBody] NewSistemaInputModel sistema)
    {
        if(_sistemaService.GetById(id) == null) return NoContent();
        _sistemaService.Update(id, sistema);
        return Ok(_sistemaService.GetById(id));
    }

    [HttpDelete("/api/sistemas/{id}")]
    public IActionResult Delete(int id)
    {
        if(_sistemaService.GetById(id) == null) return NoContent();
        _sistemaService.Delete(id);
        return Ok();
    }
}
