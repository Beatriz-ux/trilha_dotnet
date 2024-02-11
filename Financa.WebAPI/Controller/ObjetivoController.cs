using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
namespace Financa.WebAPI.Controller;
[ApiController]
[Route("/api/v0.1/")]
public class ObjetivoController: ControllerBase
{
    private readonly IObjetivo _objetivo;
    public ObjetivoController(DataBaseFake dbFake)
    {
        _objetivo = dbFake.ObjetivoCollection;
    }
    [HttpGet("objetivo")]
    public IActionResult Get()
    {
        try
        {
            var objetivos = _objetivo.GetAll().ToList();
            return Ok(objetivos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpGet("{objetivoId}")]
    public IActionResult GetByObjetivoId(int objetivoId)
    {
        try
        {
            var objetivo = _objetivo.GetById(objetivoId);
            return Ok(objetivo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    [HttpPost("objetivo")]
    public IActionResult Post([FromBody] Objetivo model)
    {
        try
        {
            _objetivo.Create(model);
            if (_objetivo != null)
            {
                return Ok(model);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
        return BadRequest();
    }
    [HttpDelete("{objetivoId}")]
    public IActionResult Delete(int objetivoId)
    {
        try
        {
            var objetivo = _objetivo.GetById(objetivoId);
            _objetivo.Delete(objetivo);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    

}
