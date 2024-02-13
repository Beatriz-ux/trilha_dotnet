namespace ResTIConnect.Application.InputModels;

public class NewUsuarioInputModel
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public int EnderecoId { get; set; }

}
