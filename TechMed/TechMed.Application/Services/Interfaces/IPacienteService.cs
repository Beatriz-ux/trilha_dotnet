using TechMed.Core.Entities;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IPacienteService
{
      public List<PacienteViewModel> GetAll();
      public Paciente GetById(int id);
      public int Create(NewPacienteInputModel medico);
      public void Update(int id, NewPacienteInputModel medico);
      public void Delete(int id);
}
