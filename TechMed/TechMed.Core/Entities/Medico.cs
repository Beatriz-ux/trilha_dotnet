namespace TechMed.Core.Entities;
public class Medico : Pessoa
{
    public int MedicoId { get; set; }
    public required string Crm { get; set; }
    
    public ICollection<Atendimento>? Atendimentos { get; }
}
