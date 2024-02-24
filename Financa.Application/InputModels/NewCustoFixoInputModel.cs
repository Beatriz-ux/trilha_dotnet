using Financa.Core.Entities;

namespace Financa.Application.InputModels
{
    public class NewCustoFixoInputModel
    {
        public float ValorParcelaFixo { get; set; }
        public DateTime DataProximaParcelaFixo { get; set; }
        public int ParcelasRestantesFixo { get; set; }
        public int IdConta { get; set; }
        public int IdCategoria { get; set; }
        public Conta Conta { get; set; }
    }
}