namespace Financa.Core.Entities;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nome { get; set; }

    public ICollection<Transacao>? Transacoes { get; set; }

}
