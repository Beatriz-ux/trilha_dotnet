namespace TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

public interface IAtendimentoService
{
    public List<AtendimentoViewModel> GetAll();
    public AtendimentoViewModel? GetById(int id);
    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
    public List<AtendimentoViewModel> GetByMedicoId(int medicoId);
    public int Create(NewAtendimentoInputModel atendimento);

}
