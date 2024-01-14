using MediatR;
namespace CleanArchitecture.Aplication.UseCases.CreateUser;

public sealed record CreateUserRequest(string Name, string Email): IRequest<CreateUserResponse>;


