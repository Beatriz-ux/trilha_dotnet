using Financa.Application.InputModels;

namespace Financa.Application.Services.Interfaces;

public interface ILoginService
{
    public int Login(NewLoginInputModel login);
}
