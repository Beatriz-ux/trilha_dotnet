using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;

namespace TechMed.Application.Services.Interfaces;
public interface IAtendimentoService
{
   public List<AtendimentoViewModel> GetAll();
   public Atendimento GetById(int id);
   public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
   public List<AtendimentoViewModel> GetByMedicoId(int medicoId);
   public int Create(NewAtendimentoInputModel atendimento);
   public void Update(int id, NewAtendimentoInputModel endereco);
   public void Delete(int id);
}
