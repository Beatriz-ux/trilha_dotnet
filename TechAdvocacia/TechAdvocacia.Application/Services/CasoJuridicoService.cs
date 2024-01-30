using TechAdvocacia.Application.InputModel;
using TechAdvocacia.Application.ViewModel;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Infrastructure.Persistence.Interfaces;

namespace TechAdvocacia.Application.Services;

public class CasoJuridicoService : BaseService, ICasoJuridicoService
{
    private readonly IClienteService _clienteService;
    private readonly IAdvogadoService _advogadoService;
    private readonly IDocumentoService _documentoService;

    public CasoJuridicoService(ITechMedContext context, IClienteService clienteService, IAdvogadoService advogadoService, IDocumentoService documentoService) : base(context)
    {
        _clienteService = clienteService;
        _advogadoService = advogadoService;
        _documentoService = documentoService;
    }

    public int Create(NewCasoJuridicoInputModel casoJuridico)
    {
        return _advogadoService.CreateAtendimento(casoJuridico.AdvogadoId, casoJuridico);
    }

    public List<CasoJuridicoViewModel> GetAll()
    {
        return _context.CasoJuridicoCollection.GetAll().Select(a => new CasoJuridicoViewModel
        {
            CasoJuridicoId = a.CasoJuridicoId,
            DataAbertura = a.Abertura,
            Cliente = new ClienteViewModel
            {
                ClienteId = a.Cliente.ClienteId,
                // Nome = a.Medico.Nome
            },
            Advogado = new AdvogadoViewModel
            {
                AdvogadoId = a.Advogado.AdvogadoId,
                //Nome = a.Paciente.Nome
            },
            Documento = new DocumentoViewModel
            {
                DocumentoId = a.Documento.DocumentoId,
                //Nome = a.Paciente.Nome
            },
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
