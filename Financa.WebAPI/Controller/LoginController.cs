using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financa.WebAPI.Controller;

public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("api/login")]
    public IActionResult Post([FromBody] NewLoginInputModel login)
    {
        login.Senha = Utils.Utils.EncryptPassword(login.Senha);
        try
        {
            var id = _loginService.Login(login);
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
