using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;

namespace ResTIConnect.API.Controllers;
[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("api/usuario")]
    public IActionResult Get()
    {
        var usuarios = _usuarioService.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("api/usuario/{id}")]
    public IActionResult Get(int id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost("api/usuario")]
    public IActionResult Post([FromBody] NewUsuarioInputModel usuario)
    {
        try
        {
            var id = _usuarioService.Create(usuario);
            var newUsuario = _usuarioService.GetById(id);
            return CreatedAtAction(nameof(Get), new { id = id }, newUsuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("api/usuario/{id}")]
    public IActionResult Put(int id, [FromBody] NewUsuarioInputModel usuario)
    {
        try
        {
            _usuarioService.Update(id, usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpDelete("api/usuario/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _usuarioService.Delete(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

}
