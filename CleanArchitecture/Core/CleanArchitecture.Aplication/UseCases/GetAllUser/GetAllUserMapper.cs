using AutoMapper;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Aplication.UseCases.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}
