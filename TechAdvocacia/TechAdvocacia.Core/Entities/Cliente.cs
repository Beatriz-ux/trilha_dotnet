namespace TechAdvocacia.Core.Entities;

public class Cliente : Pessoa
{
    public int ClienteId { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; } = new List<CasoJuridico>();



}
