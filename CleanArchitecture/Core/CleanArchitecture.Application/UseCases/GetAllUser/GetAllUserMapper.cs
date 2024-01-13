using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed class GetAllUserMapper : Profile
    {
        public GetAllUserMapper()
        {
            CreateMap<User, GetAllUserResponse>();
        }
    }
}