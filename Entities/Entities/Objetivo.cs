namespace Entities;

public class Objetivo
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<ObjetivoInvestimento> Categorias { get; }


}
