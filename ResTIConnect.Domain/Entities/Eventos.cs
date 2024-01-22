namespace ResTIConnect.Domain.Entities;


public class Eventos : BaseEntity
{
    public int EventoId { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
    public int Codigo { get; set; }
    public string Conteudo { get; set; }
    public DateTimeOffset DataHoraOcorrencia { get; set; }

}
