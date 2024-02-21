namespace Financa.Application.InputModels;

public class NewUsuarioInputModel
{
    public required string NomeUsuario { get; set; }
    public required string EmailUsuario { get; set; }
    public required string SenhaUsuario { get; set; }
    public int IdConta { get; set; }

}
