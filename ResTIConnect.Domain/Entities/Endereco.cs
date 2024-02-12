namespace ResTIConnect.Domain.Entities;

public class Endereco
{
    public int EnderecoId { get; set; }
    public string? Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cidade { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Estado { get; set; }
    public string? Cep { get; set; }
    public string? Pais { get; set; }

    public ICollection<Usuarios>? Usuarios { get; }

}
