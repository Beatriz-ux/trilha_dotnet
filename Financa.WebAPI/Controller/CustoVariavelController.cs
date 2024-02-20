// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Financa.Core.Entities;
// using Financa.Core.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Financa.Infrastructure.Persistence;



// namespace Financa.WebAPI.Controller

// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class CustoVariavelController : ControllerBase
//     {
//         private readonly ICustoVariavelCollection _custoVariavel;
//         public List<CustoVariavel> _custosVariavel = new List<CustoVariavel>();

//         public CustoVariavelController(DataBaseFake dbFake)
//         {
//             _custoVariavel = dbFake.CustoVariavelCollection;
//         }

//         [HttpGet()]
//         public IActionResult Get()
//         {
//             try
//             {
//                 var custosVariavel = _custoVariavel.GetAll().ToList();
//                 return Ok(_custoVariavel);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest($"Erro: {ex.Message}");
//             }
//         }

//         [HttpGet("{custoVariavelId}")]
//         public IActionResult GetByCustoVariaveloId(int custoVariavelId)
//         {
//             try
//             {
//                 var custoVariavel = _custoVariavel.GetById(custoVariavelId);
//                 return Ok(custoVariavel);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest($"Erro: {ex.Message}");
//             }
//         }

//         [HttpPost()]
//         public IActionResult Post([FromBody] CustoVariavel model)
//         {
//             try
//             {
//                 _custoVariavel.Create(model);

//                 if (_custoVariavel != null)
//                 {
//                     return Ok(model);
//                 }
//                 else
//                 {
//                     return BadRequest("Erro ao tentar criar um custo variável.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest($"Erro: {ex.Message}");
//             }
//         }

//         [HttpPut("{custoVariavelId}")]
//         public IActionResult Put([FromBody] CustoVariavel model)
//         {
//             try
//             {
//                 var custoVariavel = _custoVariavel.GetById(model.IdCustoVariavel);
//                 if (custoVariavel != null)
//                 {
//                     custoVariavel.ValorVariavel = model.ValorVariavel;
//                     custoVariavel.DataPlanejadaVariavel = model.DataPlanejadaVariavel;
//                     custoVariavel.IdConta = model.IdConta;
//                     custoVariavel.IdCategoria = model.IdCategoria;
//                     _custoVariavel.Update(custoVariavel);
//                     return Ok(custoVariavel);
//                 }
//                 else
//                 {
//                     return BadRequest("Custo variável não encontrado.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest($"Erro: {ex.Message}");
//             }
//         }

//         [HttpDelete("{custoVariavelId}")]
//         public IActionResult Delete(int custoVariavelId)
//         {
//             try
//             {
//                 var custoVariavel = _custoVariavel.GetById(custoVariavelId);
//                 if (custoVariavel != null)
//                 {
//                     _custoVariavel.Delete(custoVariavel);
//                     return Ok("Custo variável deletado com sucesso.");
//                 }
//                 else
//                 {
//                     return BadRequest("Custo variável não encontrado.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest($"Erro: {ex.Message}");
//             }
//         }
//     }
// }
