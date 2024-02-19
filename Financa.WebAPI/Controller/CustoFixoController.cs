// using Microsoft.AspNetCore.Mvc;
// using Financa.Core.Entities;
// using Financa.Core.Interfaces;
// using Financa.Infrastructure.Persistence;

// namespace Financa.WebAPI.Controller;

// [ApiController]
// [Route("api/[controller]")]
// public class CustoFixoController : ControllerBase
// {
//     private readonly ICustoFixoCollection _custoFixo;
//     public List<CustoFixo> _custosFixos = new List<CustoFixo>();

//     public CustoFixoController(DataBaseFake dbFake)
//     {
//         _custoFixo = dbFake.CustoFixoCollection;
//     }

//     [HttpGet()]
//     public IActionResult Get()
//     {
//         try
//         {
//             var custosFixos = _custoFixo.GetAll().ToList();
//             return Ok(custosFixos);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpGet("{custoFixoId}")]
//     public IActionResult GetByCustoFixoId(int custoFixoId)
//     {
//         try
//         {
//             var custoFixo =  _custoFixo.GetById(custoFixoId);
//             return Ok(custoFixo);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpPost()]
//     public IActionResult Post([FromBody] CustoFixo model)
//     {
//         try
//         {
//             _custoFixo.Create(model);

//             if (_custoFixo != null)
//             {
//                 return Ok(model);
//             }
//             else
//             {
//                 return BadRequest("Erro ao tentar criar um custo fixo.");
//             }
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpPut("{custoFixoId}")]
//     public IActionResult Put([FromBody] CustoFixo model)
//     {
//         try
//         {
//             var custoFixo = _custoFixo.GetById(model.IdCustoFixo);
//             if (custoFixo != null)
//             {
//                 custoFixo.ValorParcelaFixo = model.ValorParcelaFixo;
//                 custoFixo.DataProximaParcelaFixo = model.DataProximaParcelaFixo;
//                 custoFixo.ParcelasRestantesFixo = model.ParcelasRestantesFixo;
//                 custoFixo.IdCategoria = model.IdCategoria;
//                 _custoFixo.Update(custoFixo);
//                 return Ok(custoFixo);
//             }
//             else
//             {
//                 return BadRequest("Custo fixo não encontrado.");
//             }
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }

//     [HttpDelete("{custoFixoId}")]
//     public IActionResult Delete(int custoFixoId)
//     {
//         try
//         {
//             var custoFixo = _custoFixo.GetById(custoFixoId);
//             if (custoFixo != null)
//             {
//                 _custoFixo.Delete(custoFixo);
//                 return Ok("Custo fixo deletado com sucesso.");
//             }
//             else
//             {
//                 return BadRequest("Custo fixo não encontrado.");
//             }
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Erro: {ex.Message}");
//         }
//     }
// }
