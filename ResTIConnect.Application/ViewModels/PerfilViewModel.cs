using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class PerfilViewModel
    {

        public int PerfilId { get; set; }
        public string Descricao { get; set; }
        public string Permissoes { get; set; }

        public int? UsuarioId { get; set; }
    }
}
