namespace TechMed.Core.Entities;
public class Paciente : Pessoa
{
    public int PacienteId { get; set; }
    public string DataNascimento { get; set; }

    public ICollection<Atendimento>? Atendimentos { get; }
}
