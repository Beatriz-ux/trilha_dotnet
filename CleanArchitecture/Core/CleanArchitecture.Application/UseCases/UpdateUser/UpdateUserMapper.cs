using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
    public sealed class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UpdateUserResponse>();
        }
    }
}