using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infra.Persistence;

namespace TechMed.Application.Services;
public class PacienteService : IPacienteService
{
    private readonly TechMedContext _context;
    public PacienteService(TechMedContext context)
    {
        _context = context;
    }
    
    public int Create(NewPacienteInputModel paciente)
    {
        var _paciente = new Paciente
        {
            DataNascimento = paciente.DataNascimento,
            Nome = paciente.Nome,
            Cpf = paciente.Cpf
        };
        _context.Pacientes.Add(_paciente);
        _context.SaveChanges();
        return _paciente.PacienteId;
    }
    public void Delete(int id)
    {
        var _paciente = GetById(id);
        _context.Pacientes.Remove(_paciente);
        _context.SaveChanges();
    }
    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome,
            DataNascimento = m.DataNascimento,
            Cpf = m.Cpf
        }).ToList();
        if (_pacientes.Count == 0) throw new Exception("Nenhum paciente cadastrado");
        return _pacientes;
    }
    public Paciente GetById(int id)
    {
        var _paciente = _context.Pacientes.FirstOrDefault(m => m.PacienteId == id);
        if(_paciente == null) throw new Exception("Paciente não encontrado");
        return _paciente;
    }
    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetById(id);
        
        _paciente.Nome = paciente.Nome;
        _paciente.DataNascimento = paciente.DataNascimento;
        _paciente.Cpf = paciente.Cpf;
        
        _context.Pacientes.Update(_paciente);
        _context.SaveChanges();
    }
}