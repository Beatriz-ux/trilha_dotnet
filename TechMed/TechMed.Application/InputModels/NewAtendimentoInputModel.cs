namespace TechMed.Application.InputModels
{
    public class NewAtendimentoInputModel
    {
        public DateTime DataHoraInicio {get; set;}
        public string SuspeitaInicial {get; set;}
        public Decimal DataHoraFim {get; set;}
        public string Diagnostico {get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int MedicoId{get; set;}
        public int PacienteId{get; set;}
    }
}