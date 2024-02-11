using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Core.Entities
{
    public class Exame
    {
        public int ExameId { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Local { get; set; }
        public DateTime DataHora { get; set; }

        public string ResultadoDescricao { get; set; }

        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; } = null!;
    }
}