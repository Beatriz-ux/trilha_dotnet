using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financa.Core.Entities;

namespace Financa.Application.ViewModels
{
    public class CustoFixoViewModel
    {
        public int IdCustoFixo { get; set; }
        public float ValorParcelaFixo { get; set; }
        public DateTime DataProximaParcelaFixo { get; set; }
        public int ParcelasRestantesFixo { get; set; }
        public Conta Conta { get; set; }

        public int IdConta { get; set; }
        public int IdCategoria { get; set; }
    }
}