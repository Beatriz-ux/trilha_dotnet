using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infra.Persistence;

namespace TechMed.Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly TechMedDbContext _context;
    private readonly IMedicoService _medicoService;
    private readonly IPacienteService _pacienteService;

    public AtendimentoService(TechMedDbContext context, IMedicoService medicoService, IPacienteService pacienteService)
    {
        _context = context;
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    public int Create(NewAtendimentoInputModel atendimento)
    {
        return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
    }

    public List<AtendimentoViewModel> GetAll()
    {
        return _context.AtendimentosCollection.GetAll().Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHora = a.DataHora,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Diagnostico = a.Diagnostico,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt,
            DeletedAt = a.DeletedAt,
            Medico = a.Medico,
            Paciente = a.Paciente,
         Medico = new MedicoViewModel
         {
             MedicoId = a.Medico.MedicoId,
             Nome = a.Medico.Nome
         },
            Paciente = new PacienteViewModel
            {
                PacienteId = a.Paciente.PacienteId,
                Nome = a.Paciente.Nome
            }
        }).ToList();
    }

    public AtendimentoViewModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {
        throw new NotImplementedException();
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        throw new NotImplementedException();
    }
}
