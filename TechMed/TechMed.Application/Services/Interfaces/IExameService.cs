namespace TechMed.Application.Service.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

public interface IExameService
{
    public List<ExameViewModel> GetAll();
    public int Create(NewExameInputModel exame);
}
