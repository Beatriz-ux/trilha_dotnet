namespace ResTIConnect.Application.Services.InputModels;

public class NewEventosInputModel
{
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public int Codigo { get; set; }
    public string? Conteudo { get; set; }
    public DateTimeOffset DataHoraOcorrencia { get; set; }
    public List<int> Sistemas { get; set; }

}
