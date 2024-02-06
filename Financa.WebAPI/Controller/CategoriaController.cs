﻿using Microsoft.AspNetCore.Mvc;
using Entities;
using Financa.Core.Interfaces;
using Financa.Entities;
using Financa.Infrastructure.Persistence;
namespace Financa.WebAPI.Controller;

[ApiController]
[Route("/api/v0.1/")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaCollection _categoria;
    public List<Categoria> _categorias = new List<Categoria>();


    public CategoriaController(DataBaseFake dbFake)
    {
        _categoria = dbFake.CategoriaCollection;
    }

    [HttpGet]
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

    [HttpGet("{categoriaId}")]
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

    [HttpPost]
    public IActionResult Post([FromBody] Categoria model)
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

    
    [HttpDelete("{categoriaId}")]
    
    public IActionResult Delete(int categoriaId)
    {
        try
        {
            var categoria = _categoria.GetById(categoriaId
            );
            if (categoria != null)
            {
                _categoria.Delete(categoria);
                return Ok();
            }

            return BadRequest("Categoria não encontrada");
        
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

    }

}
