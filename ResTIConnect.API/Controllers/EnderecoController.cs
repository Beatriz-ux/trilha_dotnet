using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;

namespace ResTIConnect.API.Controllers;
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet ("api/endereco")]
    public IActionResult Get()
    {
        var enderecos = _enderecoService.GetAll();
        return Ok(enderecos);
    }

    [HttpGet("api/{id}")]
    public IActionResult Get(int id)
    {
        var endereco = _enderecoService.GetById(id);
        if (endereco == null)
        {
            return NotFound();
        }
        return Ok(endereco);
    }

    [HttpPost ("api/endereco")]
    public IActionResult Post([FromBody] NewEnderecoInputModel endereco)
    {
        try
        {
            var id = _enderecoService.Create(endereco);
            return CreatedAtAction(nameof(Get), new { id = id }, endereco);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("api/{id}")]
    public IActionResult Put(int id, [FromBody] NewEnderecoInputModel endereco)
    {
        _enderecoService.Update(id, endereco);
        return NoContent();
    }

    [HttpDelete("api/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _enderecoService.Delete(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }


}
