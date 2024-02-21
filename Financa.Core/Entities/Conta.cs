namespace Financa.Core.Entities;
public class Conta
{
    public int IdConta { get; set; }
    public string TipoConta { get; set; }
    public decimal SaldoConta { get; set; }
    public ICollection<CustoFixo>? CustosFixos { get; set; }
    public ICollection<CustoVariavel>? CustosVariaveis { get; set; }
    public ICollection<Transacao>? Transacoes { get; set; }
    public ICollection<Investimento>? Investimentos { get; set; }
    public required Usuario Usuario { get; set; }

}
