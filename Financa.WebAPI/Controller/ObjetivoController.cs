using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
using Microsoft.AspNetCore.Authorization;
namespace Financa.WebAPI.Controller;
[ApiController]

[Route("/api/v0.1/")]
public class ObjetivoController : ControllerBase
{
    private readonly IObjetivoService _objetivoService;

    public ObjetivoController(IObjetivoService objetivoService)
    {
        _objetivoService = objetivoService;
    }

    [HttpGet("objetivos")]
    public IActionResult GetAll()
    {
        var objetivos = _objetivoService.GetAll();
        return Ok(objetivos);
    }

    [HttpGet("objetivos/{id}")]
    public IActionResult GetById(int id)
    {
        var objetivo = _objetivoService.GetById(id);
        return Ok(objetivo);
    }

    [HttpPost("objetivos")]
    public IActionResult Create(NewObjetivoInputModel objetivo)
    {
        _objetivoService.Create(objetivo);
        return Ok(objetivo);
    }

    [HttpPut("objetivos/{id}")]
    public IActionResult Update(int id, NewObjetivoInputModel objetivo)
    {
        _objetivoService.Update(id, objetivo);
        return Ok(objetivo);
    }


}
