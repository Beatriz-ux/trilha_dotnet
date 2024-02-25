namespace TechMed.Core.Entities;
public class Pessoa : BaseEntity
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
}
