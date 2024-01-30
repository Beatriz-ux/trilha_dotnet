using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface IDocumentoService
{
    public List<DocumentoViewModel> GetAll();
    public DocumentoViewModel? GetById(int id);
    public int Create(NewDocumentoInputModel documento);
    public void Update(int id, NewDocumentoInputModel documeto);
    public void Delete(int id);
}
