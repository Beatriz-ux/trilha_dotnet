namespace CleanArchitecture.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
