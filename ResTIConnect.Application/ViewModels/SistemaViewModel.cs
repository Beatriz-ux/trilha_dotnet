﻿namespace ResTIConnect.Application.ViewModels;

public class SistemaViewModel
{
    public int SistemaId {get; set;}
    public string? Descricao {get; set;}
    public string? Tipo {get; set;}
    public string? EnderecoEntrada {get; set;}
    public string? EnderecoSaida {get; set;}
    public string? Protocolo {get; set;}
    public DateTimeOffset DataHoraInicioIntegracao {get; set;}
    public string? Status {get; set;}
    
    public List<int> UsuariosId { get; set; }
}
