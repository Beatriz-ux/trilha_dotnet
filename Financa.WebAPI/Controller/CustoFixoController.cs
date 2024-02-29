using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
using Microsoft.AspNetCore.Authorization;

namespace Financa.WebAPI.Controller;

[ApiController]
[Authorize]
[Route("/api/v0.1/")]
public class CustoFixoController : ControllerBase
{
    private readonly ICustoFixoService _custoFixo;


    public CustoFixoController(ICustoFixoService custoFixo)
    {
        _custoFixo = custoFixo;
    }


    [HttpGet("custoFixo")]
    public IActionResult Get()
    {
        try
        {
            var custoFixos = _custoFixo.GetAll().ToList();
            return Ok(custoFixos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("custoFixo/{IdCustoFixo}")]
    public IActionResult GetByCustoFixoId(int IdCustoFixo)
    {
        try
        {
            var custoFixo = _custoFixo.GetById(IdCustoFixo);
            return Ok(custoFixo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost("custoFixo")]
    public IActionResult Post([FromBody] NewCustoFixoInputModel model)
    {
        try
        {
            var newId = _custoFixo.Create(model);

            if (_custoFixo != null)
            {
                return Ok(new { id = newId });
            }
        }
        catch (Exception ex)
        {
            /*Console.WriteLine("Erro ao salvar as alterações:");
            Console.WriteLine(ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception:");
                Console.WriteLine(ex.InnerException.Message);
            }*/
            return BadRequest($"Erro: {ex.Message}");
        }

        return BadRequest();
    }


    [HttpDelete("custoFixo/{IdCustoFixo}")]

    public IActionResult Delete(int IdCustoFixo)
    {
        try
        {
            _custoFixo.Delete(IdCustoFixo);
            return Ok("Custo Fixo deletado com sucesso");

        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

    }

}
