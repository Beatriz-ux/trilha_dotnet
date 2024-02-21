using Microsoft.AspNetCore.Mvc;
using Financa.Core.Interfaces;
using Financa.Core.Entities;
using Financa.Infrastructure.Persistence;
using Financa.Application.Services.Interfaces;
using Financa.Application.InputModels;
namespace Financa.WebAPI.Controller;


[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("usuarios")]
    public IActionResult Get()
    {
        try
        {
            var usuarios = _usuarioService.GetAll();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("usuarios/{usuarioId}")]
    public IActionResult GetByUsarioId(int usuarioId)
    {
        try
        {
            var usuario = _usuarioService.GetById(usuarioId);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost("usuarios")]
    public IActionResult Post([FromBody] NewUsuarioInputModel model)
    {
        try
        {
            var id = _usuarioService.Create(model);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpDelete("usuarios/{usuarioId}")]
    public IActionResult Delete(int usuarioId)
    {
        try
        {
            _usuarioService.Delete(usuarioId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPut("usuarios/{usuarioId}")]
    public IActionResult Put(int usuarioId, [FromBody] NewUsuarioInputModel model)
    {
        try
        {
            _usuarioService.Update(usuarioId, model);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
}
// {
//     private readonly IUsuarioCollection _usuario;
//     public List<Usuario> _usuarios = new List<Usuario>();

//     public UsuarioController(DataBaseFake dbFake)
//     {
//         _usuario = dbFake.UsuarioCollection;
//     }

//     [HttpGet]
//     public IActionResult Get()
//     {
//         try
//         {
//             var usuarios = _usuario.GetAll().ToList();
//             return Ok(usuarios);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpGet("{usuarioId}")]
//     public IActionResult GetByUsarioId(int usuarioId)
//     {
//         try
//         {
//             var usuario = _usuario.GetById(usuarioId);
//             return Ok(usuario);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpPost]
//     public IActionResult Post([FromBody] Usuario model)
//     {
//         try
//         {
//             _usuario.Create(model);

//             if (_usuario != null)
//             {
//                 return Ok(model);
//             }
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }

//         return BadRequest();
//     }

//     [HttpDelete("{usuarioId}")]
//     public IActionResult Delete(int usuarioId)
//     {
//         try
//         {
//             var usuario = _usuario.GetById(usuarioId
//             );
//             if (usuario != null)
//             {
//                 _usuario.Delete(usuario);
//                 return Ok();
//             }

//             return BadRequest("Usuário não encontrado");

//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }

//     }

//     [HttpPut("{usuarioId}")]
//     public IActionResult Put(int usuarioId, [FromBody] Usuario model)
//     {
//         try
//         {
//             var usuarioExistente = _usuario.GetById(usuarioId);
//             if (usuarioExistente == null)
//             {
//                 return NotFound("Usuário não encontrado");
//             }

//             // Atualiza os dados do usuário existente com os dados do modelo recebido
//             usuarioExistente.NomeUsuario = model.NomeUsuario;
//             usuarioExistente.EmailUsuario = model.EmailUsuario;
//             usuarioExistente.SenhaUsuario = model.SenhaUsuario;
//             usuarioExistente.IdConta = model.IdConta;

//             // Chama o método de atualização do repositório
//             _usuario.Update(usuarioExistente);

//             // Retorna o usuário atualizado
//             return Ok(usuarioExistente);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }


// }
