namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    public class UpdateUserResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
