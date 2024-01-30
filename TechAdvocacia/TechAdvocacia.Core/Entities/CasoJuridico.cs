namespace TechAdvocacia.Core.Entities;

public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> ListaDocumentos { get; set; }
    public List<(float custo, string descricao)> Custos { get; set; }
    public DateTime Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }

}
