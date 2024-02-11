namespace Financa.Core.Entities;

public class Objetivo
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Investimento> Investimentos { get; set; }
    public Objetivo()
    {
        Investimentos = new List<Investimento>();
    }

}
