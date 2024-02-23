namespace TechMed.Application.InputModels;
public class NewExameInputModel
{
    public required string Nome { get; set; }
    public double Valor { get; set; }
    public required string Local { get; set; }
    public DateTime DataHora { get; set; }
    public required string ResultadoDescricao { get; set; }
    public int AtendimentoId { get; set; }
}
