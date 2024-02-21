using Financa.Core.Entities;

namespace Financa.Application.InputModels;

public class NewUsuarioInputModel
{
    public required string NomeUsuario { get; set; }
    public required string EmailUsuario { get; set; }
    public required string SenhaUsuario { get; set; }
    public required NewContaSimplesInputModel Conta { get; set; }

}
