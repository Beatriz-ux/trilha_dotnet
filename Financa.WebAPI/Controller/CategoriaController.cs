﻿using Microsoft.AspNetCore.Mvc;
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
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoria;


    public CategoriaController(ICategoriaService categoria)
    {
        _categoria = categoria;
    }


    [HttpGet ("categoria")]
    public IActionResult Get()
    {
        try
        {
            var categorias = _categoria.GetAll().ToList();
            return Ok(categorias);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("categoria/{categoriaId}")]
    public IActionResult GetByCategoriaId(int categoriaId)
    {
        try
        {
            var categoria =  _categoria.GetById(categoriaId);
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost ("categoria")]
    public IActionResult Post([FromBody] NewCategoriaInputModel model)
    {
        try
        {
            _categoria.Create(model);

            if (_categoria != null)
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

    
    [HttpDelete("categoria/{categoriaId}")]
    
    public IActionResult Delete(int categoriaId)
    {
        try
        {
            _categoria.Delete(categoriaId);
            return Ok("Categoria deletada com sucesso");
        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

    }

}
