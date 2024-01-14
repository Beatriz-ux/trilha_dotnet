using MediatR;
namespace CleanArchitecture.Aplication.UseCases.DeleteUser;

public sealed record DeleteUserRequest(Guid Id)
: IRequest<DeleteUserResponse>;
