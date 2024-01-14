using MediatR;
namespace CleanArchitecture.Aplication.UseCases.GetAllUser;

public sealed record GetAllUserRequest:
    IRequest<List<GetAllUserResponse>>;
