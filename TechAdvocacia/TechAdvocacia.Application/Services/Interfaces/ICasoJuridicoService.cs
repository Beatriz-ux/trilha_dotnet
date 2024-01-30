using TechAdvocacia.Application.InputModel;
using TechAdvocacia.Application.ViewModel;

namespace TechAdvocacia.Application.Services.Interfaces;

public interface ICasoJuridicoService
{
   public List<CasoJuridicoViewModel> GetAll();
   public CasoJuridicoViewModel? GetById(int id);
   public int Create(NewCasoJuridicoInputModel casojuridico);
   public void Update(int Id,NewCasoJuridicoInputModel casojuridico);
   public void Delete(int id);
}
