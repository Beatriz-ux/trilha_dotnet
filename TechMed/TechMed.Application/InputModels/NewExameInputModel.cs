namespace TechMed.Application.InputModel
{
    public class NewExameInputModel
    {
        public string Nome { get; set; }
        public DateTime DataHora{get; set;}
        public Decimal Valor {get; set;}
        public string Local {get; set;}
        public string ResultadoDescricao {get;set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int AtendimentoId {get; set;}
    }
}