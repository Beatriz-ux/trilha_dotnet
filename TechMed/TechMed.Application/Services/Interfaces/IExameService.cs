using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;

namespace TechMed.Application.Services.Interfaces;
public interface IExameService
{
   public List<ExameViewModel> GetAll();
   public Exame? GetById(int id);
   public int Create(NewExameInputModel exame);
   public void Update(int id, NewExameInputModel endereco);
   public void Delete(int id);
}
