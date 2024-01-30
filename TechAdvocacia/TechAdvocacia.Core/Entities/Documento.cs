namespace TechAdvocacia.Core.Entites;
public class Documento : BaseEntity
{
    public int DocumentoId { get; set; }
    public DateTime DataHora { get; set; }
    public int Codigo { get; set; }
    public string? Descricao { get; set; }

}
