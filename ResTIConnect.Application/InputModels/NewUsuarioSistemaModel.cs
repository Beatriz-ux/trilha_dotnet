using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.InputModels;

public class NewUsuarioSistemaInputModel
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }

    public NewSistemaSimplesInputModel Sistema { get; set; }
    public List<int> PerfisId { get; set; }

}
