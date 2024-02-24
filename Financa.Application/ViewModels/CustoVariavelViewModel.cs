using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financa.Core.Entities;

namespace Financa.Application.ViewModels
{
    public class CustoVariavelViewModel
    {
        public int IdCustoVariavel { get; set; }
        public float ValorVariavel { get; set; }
        public DateTime DataPlanejadaVariavel { get; set; }
        public int IdConta { get; set; }
        public int IdCategoria { get; set; }
        public Conta Conta { get; set; }
    }
}