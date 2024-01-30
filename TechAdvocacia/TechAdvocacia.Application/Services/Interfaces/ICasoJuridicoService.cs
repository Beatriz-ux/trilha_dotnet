using TechAdvocacia.Application.InputModel;
using TechAdvocacia.Application.ViewModel;

namespace TechAdvocacia.Application.Services.Interfaces;

public interface ICasoJuridicoService
{
   public List<CasoJuridicoViewModel> GetAll();
   public CasoJuridicoViewModel? GetById(int id);
   public List<CasoJuridicoViewModel> GetByPacienteId(int pacienteId);
   public List<CasoJuridicoViewModel> GetByMedicoId(int medicoId);
   public int Create(NewCasoJuridicoInputModel atendimento);
}
