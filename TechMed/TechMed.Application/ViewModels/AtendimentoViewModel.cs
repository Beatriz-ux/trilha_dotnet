namespace TechMed.Application.ViewModels{

public class AtendimentoViewModel
{
    public int AtendimentoId{get; set;}
    public DateTime DataHoraInicio {get; set;}
        public string SuspeitaInicial {get; set;}
        public Decimal DataHoraFim {get; set;}
        public string Diagnostico {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public MedicoViewModel Medico{get; set;} = null!;
        public PacienteViewModel Paciente {get; set;} = null!;
}   
}