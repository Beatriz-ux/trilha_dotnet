namespace CleanArchitecture.Aplication.UseCases.GetAllUser;

public sealed record GetAllUserResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}

