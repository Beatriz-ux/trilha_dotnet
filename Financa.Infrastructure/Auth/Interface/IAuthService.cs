namespace Financa.Infrastructure.Auth.Interface
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string pass);
        string GenerateJwtToken(string email, string role);
        string GetRoleFromToken(string token);
    }
}
