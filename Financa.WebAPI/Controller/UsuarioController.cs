using Microsoft.AspNetCore.Mvc;
using Financa.Core.Interfaces;
using Financa.Core.Entities;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
using Financa.WebAPI.Utils;
namespace Financa.WebAPI.Controller;


[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("usuarios")]
    public IActionResult Get()
    {
        try
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("usuarios/{usuarioId}")]
    public IActionResult GetByUsarioId(int usuarioId)
    {
        try
        {
            var usuario = _usuarioService.GetById(usuarioId);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost("usuarios")]
    public IActionResult Post([FromBody] NewUsuarioInputModel model)
    {
        model.SenhaUsuario = Utils.Utils.EncryptPassword(model.SenhaUsuario);
        try
        {
            var id = _usuarioService.Create(model);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpDelete("usuarios/{usuarioId}")]
    public IActionResult Delete(int usuarioId)
    {
        try
        {
            _usuarioService.Delete(usuarioId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPut("usuarios/{usuarioId}")]
    public IActionResult Put(int usuarioId, [FromBody] NewUsuarioInputModel model)
    {
        model.SenhaUsuario = Utils.Utils.EncryptPassword(model.SenhaUsuario);
        try
        {
            _usuarioService.Update(usuarioId, model);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}
