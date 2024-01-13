using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(string Email, string Name) :
                                      IRequest<CreateUserResponse>;

}