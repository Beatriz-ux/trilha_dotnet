namespace Entities;

public class Transacao
{
    public int IdTransacao { get; set; }
    public float ValorTransacao { get; set; }
    public DateTime DataTransacao { get; set; }
    public string? TipoTransacao { get; set; }
    public int IdConta { get; set; }
    public int IdCategoria { get; set; }
    public Conta Conta { get; set; }

    //list do outra tabela intermediaria


    /*
    transacaoESeila id
    public id de cada uma
    
    */

}
