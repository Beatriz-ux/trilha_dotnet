﻿namespace Entities;

public class ObjetivoInvestimento
{
    public int IdObjetivo { get; set; }
    public int IdInvestimento { get; set; }
    public Objetivo Objetivo { get; set; }
    public Investimento Investimento { get; set; }

}
