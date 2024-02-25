using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financa.Application.InputModels
{
    public class NewCustoVariavelModelInputModel
    {
        public float ValorVariavel { get; set; }
        public DateTime DataPlanejadaVariavel { get; set; }
        public int IdConta { get; set; }
        public int IdCategoria { get; set; }
    }
}