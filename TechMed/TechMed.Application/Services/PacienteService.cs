using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infra.Persistence;
namespace TechMed.Application.Services;


public class PacienteService : IPacienteService
{
    private int _nextPacienteId = 1;
    private readonly TechMedDbContext _context;
    public PacienteService(TechMedDbContext context)
    {
        _context = context;
    }

    private Paciente GetByDbId(int id)
    {
        var _paciente = _context.Pacientes.Find(id);

        if (_paciente is null)
            throw new PacienteNotFoundException();
        
        return _paciente;
    }

    public int Create(NewPacienteInputModel paciente)
    {
        var newPacienteId = _nextPacienteId++;
        var _paciente = new Paciente
        {
            PacienteId = newPacienteId,
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNascimento = paciente.DataNascimento,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.MinValue
        };
        _context.Pacientes.Add(_paciente);

        _context.SaveChanges();

        return _paciente.PacienteId;
    }

    public void Delete(int id)
    {   var _paciente = GetByDbId(id);
        _paciente.DeletedAt = DateTime.Now;
        _context.Pacientes.Remove(_paciente);

        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(p => new PacienteViewModel
        {
            PacienteId = p.PacienteId,
            Nome = p.Nome
        }).ToList();

        return _pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome
        };
        return PacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetByDbId(id);
        _paciente.UpdatedAt =  DateTime.Now;

        _paciente.Nome = paciente.Nome;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}
