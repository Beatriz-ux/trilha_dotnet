using Financa.Application.InputModels;

namespace Financa.Application.Services.Interfaces;

public interface ILoginService
{
    public string Login(NewLoginInputModel login);
}
