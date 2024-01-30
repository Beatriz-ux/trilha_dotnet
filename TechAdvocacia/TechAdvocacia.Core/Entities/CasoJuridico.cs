namespace TechAdvocacia.Core.Entities;
using System.Collections.Generic;

public class CasoJuridico : BaseEntity
{
    public int CasoJuridicoId {get; set;}
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> ListaDocumentos { get; set; }
    // public List<(float custo, string descricao)> Custos { get; set; }
    public DateTime Encerramento { get; set; }
    //public List<Advogado> Advogados { get; set; }
    //colocar as chaves estrangeiras , no caso o atributo ClienteId por exemplo
    public int ClienteId { get; set; }
    public int AdvogadoId { get; set; }
    public int DocumentoId { get; set; }
    public Cliente Cliente { get; set; }
    public Advogado Advogado {get; set;}
    public Documento Documento {get; set;}
    public string Status { get; set; }

}
