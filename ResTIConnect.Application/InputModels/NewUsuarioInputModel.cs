namespace ResTIConnect.Application.InputModels;

//esse vai ser a classe que vai receber um novo usario e linkar a um sistema existente
public class NewUsuarioInputModel
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }
    public int SistemasId {get; set;}

    public List<int> PerfisId { get; set; }
}
