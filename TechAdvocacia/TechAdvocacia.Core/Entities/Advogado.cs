
namespace TechAdvocacia.Core.Entities;

public class Advogado : Pessoa
{
    public int AdvogadoId { get; set; }
    public string CNA { get; set; }

    public List<CasoJuridico> CasosJuridicos { get; set; } = new List<CasoJuridico>();

}
