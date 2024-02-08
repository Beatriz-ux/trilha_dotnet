using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Core.Entities
{
    public class Atendimento
    {
        public int AtendimentoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string SuspeitaInicial { get; set; }
        public string Diagnostico { get; set; }

        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

    }
}