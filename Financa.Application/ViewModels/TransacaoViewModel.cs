namespace Financa.Application.ViewModels;

public class TransacaoViewModel
{
    public int IdTransacao { get; set; }
    public float ValorTransacao { get; set; }
    public DateTime DataTransacao { get; set; }
    public string? TipoTransacao { get; set; }
    public ContaViewModel? Conta { get; set; }
    public CategoriaViewModel? Categoria { get; set; }
}
