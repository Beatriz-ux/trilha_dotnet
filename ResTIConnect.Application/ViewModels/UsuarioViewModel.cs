namespace ResTIConnect.Application.ViewModels;

public class UsuarioViewModel
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    
    public EnderecoUserViewModel Endereco { get; set; }
    public List<int> SistemasId { get; set; }
}
