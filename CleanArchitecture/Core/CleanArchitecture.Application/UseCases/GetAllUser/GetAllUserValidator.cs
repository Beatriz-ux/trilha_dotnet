using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
    {
        public GetAllUserValidator()
        {
            // Sem validação
        }
    }
}
