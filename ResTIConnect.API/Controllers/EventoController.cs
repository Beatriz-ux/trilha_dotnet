using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.InputModels;
using ResTIConnect.Application.Services.Interfaces;
namespace ResTIConnect.API.Controllers;
[ApiController]
[Authorize]


public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet("api/api/evento")]
    public IActionResult Get()
    {
        var eventos = _eventoService.GetAll();
        return Ok(eventos);
    }

    [HttpGet("api/evento/{id}")]
    public IActionResult Get(int id)
    {
        var evento = _eventoService.GetById(id);
        if (evento == null)
        {
            return NotFound();
        }
        return Ok(evento);
    }

    [HttpPost("api/api/evento")]
    public IActionResult Post([FromBody] NewEventosInputModel evento)
    {
        try
        {
            var id = _eventoService.Create(evento);
            return CreatedAtAction(nameof(Get), new { id = id }, evento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("api/evento/{id}")]
    public IActionResult Put(int id, [FromBody] NewEventosInputModel evento)
    {
        _eventoService.Update(id, evento);
        return NoContent();
    }

    [HttpPut("api/evento-with-sistema")]
    public IActionResult Put([FromBody] NewEventoSistemaInputModel evento)
    {
        try
        {
            _eventoService.AddSistema(evento);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("api/evento/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _eventoService.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("api/evento-with-sistema")]
    public IActionResult Delete([FromBody] NewEventoSistemaInputModel evento)
    {
        try
        {
            _eventoService.RemoveSistema(evento);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
