using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}