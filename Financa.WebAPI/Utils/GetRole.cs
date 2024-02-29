using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Financa.WebAPI.Utils;

public class GetRole
{
    private readonly IConfiguration _configuration;

    public GetRole(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
}
