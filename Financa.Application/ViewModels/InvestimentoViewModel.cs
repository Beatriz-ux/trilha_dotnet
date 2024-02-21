namespace Financa.Application.ViewModels;

public class InvestimentoViewModel
{
    public int IdInvestimento { get; set; }
    public string Nome { get; set; }
    public decimal ValorInvestido { get; set; }
    public DateTime DataCompra { get; set; }
    public decimal TaxaDeRetorno { get; set; }

    public int IdConta { get; set; }

    public ICollection<string> NomesObjetivos { get; set; }

}
