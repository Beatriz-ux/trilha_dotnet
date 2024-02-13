namespace TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

public interface IPacienteService
{
    public List<PacienteViewModel> GetAll();
    public PacienteViewModel? GetById(int id);
    public int Create(NewPacienteInputModel paciente);
    public void Update(int id, NewPacienteInputModel paciente);
    public void Delete(int id);
}
