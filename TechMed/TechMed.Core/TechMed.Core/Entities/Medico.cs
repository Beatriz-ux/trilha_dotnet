using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Core.Entities
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nome{ get; set;}
        public string Crm { get; set; }
        public string Cpf { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public ICollection<Atendimento>? Atendimentos {get;}
    }
}