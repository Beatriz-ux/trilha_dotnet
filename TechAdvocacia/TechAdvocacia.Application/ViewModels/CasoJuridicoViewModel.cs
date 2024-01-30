using TechAdvocacia.Application.ViewModels;
namespace TechAdvocacia.Application.ViewModel;

public class CasoJuridicoViewModel
{
    public int CasoJuridicoId {get; set;}
    public DateTime Abertura { get; set; }
    public ClienteViewModel Cliente { get; set; } = null!;
    public AdvogadoViewModel Advogado { get; set; } = null!;
    public DocumentoViewModel Documento { get; set; } = null!;



}
