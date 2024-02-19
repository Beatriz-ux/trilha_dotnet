namespace Financa.Application.ViewModels;

public class ObjetivoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<int> Investimentos { get; set; }

}
