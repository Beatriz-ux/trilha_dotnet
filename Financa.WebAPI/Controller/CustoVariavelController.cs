using Microsoft.AspNetCore.Mvc;
using Financa.Core.Entities;
using Financa.Core.Interfaces;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
namespace Financa.WebAPI.Controller;

[ApiController]
[Route("/api/v0.1/")]
public class CustoVariavelController : ControllerBase
{
    private readonly ICustoVariavelService _custoVariavel;


    public CustoVariavelController(ICustoVariavelService custoVariavel)
    {
        _custoVariavel = custoVariavel;
    }


    [HttpGet ("custoVariavel")]
    public IActionResult Get()
    {
        try
        {
            var custosVariaveis = _custoVariavel.GetAll().ToList();
            return Ok(custosVariaveis);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("custoVariavel/{IdCustoVariavel}")]
    public IActionResult GetByCustoVariavelId(int IdCustoVariavel)
    {
        try
        {
            var custoVariavel =  _custoVariavel.GetById(IdCustoVariavel);
            return Ok(custoVariavel);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost ("custoVariavel")]
    public IActionResult Post([FromBody] NewCustoVariavelModelInputModel model)
    {
        try
        {
            _custoVariavel.Create(model);

            if (_custoVariavel != null)
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

    
    [HttpDelete("custoVariavel/{IdCustoVariavel}")]
    
    public IActionResult Delete(int IdCustoVariavel)
    {
        try
        {
            _custoVariavel.Delete(IdCustoVariavel);
            return Ok("Custo variável deletado com sucesso");
        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

    }

}
