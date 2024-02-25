namespace TechMed.Core.Entities;

public class Atendimento : BaseEntity
{
    public int AtendimentoId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public required string SuspeitaInicial { get; set; }
    public required string Diagnostico { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    
    public required Medico Medico { get; set; }

    public required Paciente Paciente { get; set; }

    public ICollection<Exame>? Exames { get; set; }
}
