using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.InputModels
{
    public class NewPerfilInputModel
    {
         public string Descricao {get; set;}
         public string Permissoes {get; set;}

         public int? UsuarioId { get; set; }
    }
}
