namespace TechMed.Application.InputModels;
public class NewPacienteInputModel
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required string DataNascimento { get; set; }
}
