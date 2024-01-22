namespace Entities;

public class CustoVariavel
{
    public int IdCustoVariavel { get; set; }
    public float ValorVariavel { get; set; }
    public DateTime DataPlanejadaVariavel  { get; set; }
    public int IdConta { get; set; }
    public int IdCategoria { get; set; }
    public Conta Conta { get; set; }

}
