using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Infra.Data.Models;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Application.InputModels;
using Microsoft.AspNetCore.Authorization;
namespace ResTIConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;
        public List<PerfilViewModel> Perfis => _perfilService.GetAll();
        public PerfilController(IPerfilService service) => _perfilService = service;

        [HttpGet("perfis")]
        public IActionResult Get()
        {
            return Ok(Perfis);
        }

        [HttpGet("perfil/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var perfil = _perfilService.GetById(id);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("perfil")]
        public IActionResult Post([FromBody] NewPerfilInputModel perfil)
        {
            _perfilService.Create(perfil);

            return CreatedAtAction(nameof(Get), perfil);
        }

        [HttpPut("perfil/{id}")]
        public IActionResult Put(int id, [FromBody] NewPerfilInputModel perfil)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Update(id, perfil);
            return Ok(_perfilService.GetById(id));
        }

        [HttpDelete("perfil/{id}")]
        public IActionResult Delete(int id)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Delete(id);
            return Ok();
        }
    }
}
