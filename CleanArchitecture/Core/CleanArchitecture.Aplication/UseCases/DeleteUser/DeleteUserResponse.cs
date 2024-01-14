namespace CleanArchitecture.Aplication.UseCases.DeleteUser;

public sealed record DeleteUserResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

}
