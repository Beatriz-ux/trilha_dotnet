using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.WebAPI.Controller;

public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public List<ClienteViewModel> Clientes =>  _clienteService.GetAll();

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("Clientes")]
    public IActionResult Get()
    {
        return Ok(Clientes);
    }

    [HttpGet("Clientes/{id}")]
    public IActionResult GetById(int id)
    {
        var _cliente = _clienteService.GetById(id);
        if(_cliente == null) return NotFound();
        return Ok(_cliente);
    }

    [HttpPost("Clientes")]
    public IActionResult Post([FromBody] NewClienteInputModel cliente)
    {
        var _id = _clienteService.Create(cliente);
        return CreatedAtAction(nameof(GetById), new {id = _id}, cliente);
    }

    [HttpPut("Clientes/{id}")]
    public IActionResult Put(int id, [FromBody] NewClienteInputModel cliente)
    {
        _clienteService.Update(id, cliente);
        return NoContent();
    }

    [HttpDelete("Clientes/{id}")]
    public IActionResult Delete(int id)
    {
        _clienteService.Delete(id);
        return NoContent();
    }

  
}
