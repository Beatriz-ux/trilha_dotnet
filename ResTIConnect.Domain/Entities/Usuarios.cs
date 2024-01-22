namespace ResTIConnect.Domain.Entities;
public class Usuarios : BaseEntity
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Telefone { get; set; }
}
