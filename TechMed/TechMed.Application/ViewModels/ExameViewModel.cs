using TechMed.Core.Entities;

namespace TechMed.Application.ViewModels;

public class ExameViewModel
{
    public int ExameId { get; set; }
    public required string Nome { get; set; }
    public double Valor { get; set; }
    public required string Local { get; set; }
    public DateTime DataHora { get; set; }
    public required string ResultadoDescricao { get; set; }
    public Atendimento Atendimento { get; set; } = null!;
}
