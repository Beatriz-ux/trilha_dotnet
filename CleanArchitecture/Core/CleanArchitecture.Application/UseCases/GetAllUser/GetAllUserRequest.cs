using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed record GetAllUserRequest :
                   IRequest<List<GetAllUserResponse>>;
}