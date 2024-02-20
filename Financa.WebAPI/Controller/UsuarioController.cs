// using Microsoft.AspNetCore.Mvc;
// using Financa.Core.Interfaces;
// using Financa.Core.Entities;
// using Financa.Infrastructure.Persistence;
// namespace Financa.WebAPI.Controller;


// [ApiController]
// [Route("/api/v0.1/")]
// public class UsuarioController : ControllerBase
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
