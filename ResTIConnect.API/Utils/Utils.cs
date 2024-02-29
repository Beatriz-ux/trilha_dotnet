using System.Security.Cryptography;
using System.Text;

namespace ResTIConnect.API.Utils;
public abstract class Utils
{

    // Método para criptografar a senha
    public static string EncryptPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            // Convertendo a senha em bytes
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            // Calculando o hash SHA256
            byte[] hash = sha256.ComputeHash(bytes);

            // Convertendo o hash em uma string Base64
            return Convert.ToBase64String(hash);
        }
    }

}
