namespace Entities;

public class Investimento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal ValorInvestido { get; set; }
    public DateTime DataCompra { get; set; }
    public decimal TaxaDeRetorno { get; set; }

    public ICollection<ObjetivoInvestimento> Categorias { get; }
}

