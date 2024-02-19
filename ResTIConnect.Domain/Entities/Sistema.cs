namespace ResTIConnect.Domain.Entities;

public class Sistema : BaseEntity
{
    public int SistemaId { get; set; }
    public string? Descricao { get; set; }
    public string? Tipo { get; set; }
    public string? EnderecoEntrada { get; set; }
    public string? EnderecoSaida { get; set; }
    public string? Protocolo { get; set; }
    public DateTimeOffset DataHoraInicioIntegracao { get; set; }
    public string? Status { get; set; }
    
    public ICollection<Usuarios>? Usuarios { get; set; }

    public ICollection<Eventos>? Eventos { get;set; } 
}
