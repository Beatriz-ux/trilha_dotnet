using ResTIConnect.Application.Services.ViewModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.ViewModels;

public class EventoViewModel
{
    public int Id { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public int Codigo { get; set; }
    public string? Conteudo { get; set; }
    public DateTimeOffset DataHoraOcorrencia { get; set; }
    
    public List<int> SistemasId { get; set; }

}
