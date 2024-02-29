using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces;

public interface ILoginService
{
    public int Login(NewLoginInputModel login);

}
