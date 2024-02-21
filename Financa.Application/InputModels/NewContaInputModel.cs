﻿using Financa.Core.Entities;
namespace Financa.Application.InputModels;

public class NewContaInputModel
{
    public string TipoConta { get; set; }
    public decimal SaldoConta { get; set; }
    public ICollection<CustoFixo>? CustosFixos { get; set; }
    public ICollection<CustoVariavel>? CustosVariaveis { get; set; }
    public ICollection<Transacao>? Transacoes { get; set; }
    public ICollection<Investimento>? Investimentos { get; set; }
}
