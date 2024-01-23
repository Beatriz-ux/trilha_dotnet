namespace Entities;
public class Conta
{
    public Guid IdConta { get; set; }
    public string TipoConta { get; set; }
    public decimal SaldoConta { get; set; }
    public ICollection<CustoFixo>? CustosFixos { get; set; }
    public ICollection<CustoVariavel>? CustosVariaveis { get; set; }
    public ICollection<Transacao>? Transacoes { get; set; }

}
