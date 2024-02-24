using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
namespace Financa.WebAPI.Controller;

[ApiController]
[Route("/api/v0.1/")]
public class CustoFixoController : ControllerBase
{
    private readonly ICustoFixoService _custoFixo;


    public CustoFixoController(ICustoFixoService custoFixo)
    {
        _custoFixo = custoFixo;
    }


    [HttpGet ("custoFixo")]
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
    public IActionResult GetByCustoFixoId(int custoFixoId)
    {
        try
        {
            var custoFixo =  _custoFixo.GetById(custoFixoId);
            return Ok(custoFixo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost ("custoFixo")]
    public IActionResult Post([FromBody] NewCustoFixoInputModel model)
    {
        try
        {
            _custoFixo.Create(model);

            if (_custoFixo != null)
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

    
    [HttpDelete("custoFixo/{IdCustoFixo}")]
    
    public IActionResult Delete(int custoFixoId)
    {
        try
        {
            _custoFixo.Delete(custoFixoId);
            return Ok("Custo Fixo deletado com sucesso");
        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

    }

}
