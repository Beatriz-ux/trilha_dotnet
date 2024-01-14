using AutoMapper;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Aplication.UseCases.DeleteUser;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, User>();
        CreateMap<User, DeleteUserResponse>();
    }
}
