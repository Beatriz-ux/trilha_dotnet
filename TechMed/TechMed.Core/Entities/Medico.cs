namespace TechMed.Core.Entities;
public class Medico
{
    public int MedicoId { get; set; }
    public string Crm { get; set; }

    public ICollection<Atendimento>? Atendimentos { get; }
}
