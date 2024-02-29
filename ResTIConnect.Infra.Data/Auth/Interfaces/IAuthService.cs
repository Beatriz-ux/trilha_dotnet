namespace ResTIConnect.Infra.Data.Auth.Interfaces;

public interface IAuthService
{
   string GenerateJwtToken(string email, string role); 
   string ComputeSha256Hash(string pass);
   public string GetRoleFromToken(string token);
}
