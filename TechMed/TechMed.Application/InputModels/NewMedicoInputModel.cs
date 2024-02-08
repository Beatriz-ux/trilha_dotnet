using System.Dynamic;

namespace TechMed.Application.InputModels
{
    public class NewMedicoInputModel
    {
        public string Nome {get; set;}
        public string Crm {get; set;}
        public string Cpf{get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}