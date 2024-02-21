namespace Financa.Application.InputModels;

public class NewInvestimentoInputModel
{
    public string Nome { get; set; }
    public decimal ValorInvestido { get; set; }
    public DateTime DataCompra { get; set; }
    public decimal TaxaDeRetorno { get; set; }

    public int IdConta { get; set; }

    public ICollection<int> Objetivos { get;set; }

}
