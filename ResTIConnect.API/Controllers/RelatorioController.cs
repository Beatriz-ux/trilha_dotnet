using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services;
using ResTIConnect.Application.Services.Interfaces;
namespace ResTIConnect.API.Controllers;

public class RelatorioController : ControllerBase
{
    private readonly RelatoriosService _relatoriosService;

    public RelatorioController(RelatoriosService relatoriosService)
    {
        _relatoriosService = relatoriosService;
    }

    [HttpGet("/users/profile/{id}")]
    public IActionResult GetUsersByProfile(int id)
    {
        var usuarios = _relatoriosService.UserFilterByProfile(id);
        return Ok(usuarios);
    }

    [HttpGet("/users/address/{uf}")]
    public IActionResult GetUsersByState(string uf)
    {
        var usuarios = _relatoriosService.UserFilterByState(uf);
        return Ok(usuarios);
    }

    [HttpGet("/system/users/{id}")]
    public IActionResult GetUsersBySystem(int id)
    {
        var sistemas = _relatoriosService.SystemsFilterByUser(id);
        return Ok(sistemas);
    }

    [HttpGet("/system/event/{type}/from/{date}")]
    public IActionResult GetSystemEvents(string type, string date)
    {
        var sistemas = _relatoriosService.SystemsFilterByEventTypeFromDate(type, date);
        return Ok(sistemas);
    }

}
