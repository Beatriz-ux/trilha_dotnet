﻿namespace Financa.Core.Entities;
public class Usuario
{
    public int IdUsuario { get; set; }
    public string? NomeUsuario { get; set; }
    public string? EmailUsuario { get; set; }
    public string? SenhaUsuario { get; set; }
    public int IdConta { get; set; }
}
