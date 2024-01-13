using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {
        //sem validação    
    }
}
}