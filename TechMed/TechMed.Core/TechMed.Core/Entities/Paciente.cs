using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Core.Entities
{
    public class Paciente : Pessoa
    {

        public int PacienteId { get; set; }
        public string DataNascimento { get; set; }

        public ICollection<Atendimento>? Atendimentos {get;}
    }
}