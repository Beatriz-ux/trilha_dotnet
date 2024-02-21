namespace Financa.Core.Entities;

public class Investimento
{
    public int IdInvestimento { get; set; }
    public string Nome { get; set; }
    public decimal ValorInvestido { get; set; }
    public DateTime DataCompra { get; set; }
    public decimal TaxaDeRetorno { get; set; }

    public int IdConta { get; set; }

    public Conta Conta { get; set; }

    public ICollection<Objetivo> Objetivos { get;set; }

}

