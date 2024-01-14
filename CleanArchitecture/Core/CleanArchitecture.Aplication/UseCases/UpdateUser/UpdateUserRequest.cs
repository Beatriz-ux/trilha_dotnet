using MediatR;
namespace CleanArchitecture.Aplication.UseCases.UpdateUser;


public sealed record UpdateUserRequest(
    Guid Id,
    string? Name,
    string? Email
) : IRequest<UpdateUserResponse>;

