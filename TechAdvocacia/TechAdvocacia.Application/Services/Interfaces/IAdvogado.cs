using TechAdvocacia.Application.InputModels;

namespace TechAdvocacia.Application.Services.Interfaces;

public interface IAdvogado
{
    public List<AdvogadoViewModel> GetAll();
    public AdvogadoViewModel? GetById(int id);
    public int Create(NewAdvogadoInputModel advogado);
    public void Update(int Id,NewAdvogadoInputModel advogado);
    public void Delete(int id);

}
