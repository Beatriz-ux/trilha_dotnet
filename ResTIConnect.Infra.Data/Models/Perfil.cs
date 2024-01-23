using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Infra.Data.Models
{
    public class Perfil
    {
         public int PerfilId { get; set; }
         public string? Descricao {get; set;}
         public string? Permissoes {get; set;}
         
    }
}