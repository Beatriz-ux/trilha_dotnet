namespace ResTIConnect.Domain.Entities; //troquei para a pasta Entities , antes estava na pasta Common. No Cepedi eles usam nessa pasta

public abstract class BaseEntity
{
   // public Guid Id { get; set; } // como cada tabela tem id proprio, não precisa mais do id aqui
    // public DateTimeOffset DateCreated { get; set; }
    // public DateTimeOffset? DateUpdated { get; set; }
    // public DateTimeOffset? DateDeleted { get; set; }
}
