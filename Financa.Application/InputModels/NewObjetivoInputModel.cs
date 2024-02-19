namespace Financa.Application.InputModels;

public class NewObjetivoInputModel
{
    public string Nome { get; set; }
    public ICollection<int> Investimentos { get; set; }
}
