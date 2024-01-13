using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, User>();
        CreateMap<User, DeleteUserResponse>();
    }
}
}