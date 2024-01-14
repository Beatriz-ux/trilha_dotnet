using System.Data;
using FluentValidation;

namespace CleanArchitecture.Aplication.UseCases.DeleteUser;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
    }

}
