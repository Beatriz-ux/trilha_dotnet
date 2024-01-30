namespace TechAdvocacia.Core.Entities;

public abstract class Pessoa : BaseEntity
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }

}
