namespace Financa.Application.InputModels;

public class NewTransacaoInputModel
{
    public float ValorTransacao { get; set; }
    public DateTime DataTransacao { get; set; }
    public string? TipoTransacao { get; set; }
    public int IdConta { get; set; }
    public int IdCategoria { get; set; }
}
