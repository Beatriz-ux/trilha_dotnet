namespace CleanArchitecture.Aplication.UseCases.UpdateUser;

public sealed record UpdateUserResponse
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }

}
