namespace TechMed.Application.ViewModels;

public class MedicoViewModel
{
    public int MedicoId { get; set; }
    public required string Nome { get; set; }
    public required string Crm { get; set; }
    public required string Cpf { get; set; }
}
