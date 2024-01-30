namespace TechAdvocacia.Application.ViewModel;

public class CasoJuridicoViewModel
{
    public int CasoJuridicoId {get; set;}
    public DateTime Abertura { get; set; }
    public ClienteViewModel Paciente { get; set; } = null!;
    public AdvogadoViewModel Advogado { get; set; } = null!;
    public DocumentoViewModel Documento { get; set; } = null!;

}
