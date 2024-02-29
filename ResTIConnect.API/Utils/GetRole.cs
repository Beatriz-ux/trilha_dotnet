using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ResTIConnect.API;

public class GetRole
{
    private readonly IConfiguration _configuration;

    public GetRole(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
}
