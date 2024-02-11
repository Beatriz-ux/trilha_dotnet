using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces;

public interface ISistemaService
{
    public List<SistemaViewModel> GetAll();
    public SistemaViewModel? GetById(int id);
    public int Create(NewSistemaInputModel sistema);
    public void Update(int id, NewSistemaInputModel sistema);
    public void Delete(int id);
}
