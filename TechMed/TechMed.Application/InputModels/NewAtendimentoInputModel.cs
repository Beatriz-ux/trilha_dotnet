using TechMed.Core.Entities;

namespace TechMed.Application.InputModels;
public class NewAtendimentoInputModel
{
   public DateTime DataHoraInicio { get; set; }
   public DateTime DataHoraFim { get; set; }
   public required string SuspeitaInicial { get; set; }
   public required string Diagnostico { get; set; }
   public int MedicoId { get; set; }
   public int PacienteId { get; set; }
}
