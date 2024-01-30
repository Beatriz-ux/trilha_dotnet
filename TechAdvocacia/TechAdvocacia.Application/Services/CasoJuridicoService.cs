using TechAdvocacia.Application.InputModel;
using TechAdvocacia.Application.ViewModel;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Infrastructure.Persistence;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services;

public class CasoJuridicoService : ICasoJuridicoService
{
    private readonly IClienteService _clienteService;
    private readonly IAdvogadoService _advogadoService;
    private readonly IDocumentoService _documentoService;

    private readonly TechAdvocaciaDbContext _context;

    public CasoJuridicoService(TechAdvocaciaDbContext context, IClienteService clienteService, IAdvogadoService advogadoService, IDocumentoService documentoService)
    {
        _clienteService = clienteService;
        _advogadoService = advogadoService;
        _documentoService = documentoService;
        _context = context;
    }

    public int Create(NewCasoJuridicoInputModel casoJuridico)
    {
        var _casoJuridico = new CasoJuridico
        {
            Abertura = casoJuridico.Abertura,
            ClienteId = casoJuridico.ClienteId,
            AdvogadoId = casoJuridico.AdvogadoId,
            DocumentoId = casoJuridico.DocumentoId
        };

        _context.CasosJuridicos.Add(_casoJuridico);

        _context.SaveChanges();

        return _casoJuridico.CasoJuridicoId;
    }

    public List<CasoJuridicoViewModel> GetAll()
    {
        var _casosJuridicos = _context.CasosJuridicos.ToList();
        var _casosJuridicosViewModel = new List<CasoJuridicoViewModel>();
        foreach (var _casoJuridico in _casosJuridicos)
        {
            var _casoJuridicoViewModel = new CasoJuridicoViewModel
            {
                CasoJuridicoId = _casoJuridico.CasoJuridicoId,
                Abertura = _casoJuridico.Abertura,
                Cliente = _clienteService.GetById(_casoJuridico.ClienteId),
                Advogado = _advogadoService.GetById(_casoJuridico.AdvogadoId),
                Documento = _documentoService.GetById(_casoJuridico.DocumentoId)
            };
            _casosJuridicosViewModel.Add(_casoJuridicoViewModel);
        }
        return _casosJuridicosViewModel;
    }

    public CasoJuridicoViewModel? GetById(int id)
    {
        var _casoJuridico = _context.CasosJuridicos.Find(id);
        if (_casoJuridico == null) return null;
        var _casoJuridicoViewModel = new CasoJuridicoViewModel
        {
            CasoJuridicoId = _casoJuridico.CasoJuridicoId,
            Abertura = _casoJuridico.Abertura,
            Cliente = _clienteService.GetById(_casoJuridico.ClienteId),
            Advogado = _advogadoService.GetById(_casoJuridico.AdvogadoId),
            Documento = _documentoService.GetById(_casoJuridico.DocumentoId)
        };
        return _casoJuridicoViewModel;

    }
    
    CasoJuridicoViewModel? ICasoJuridicoService.GetById(int id)
    {
        var _casoJuridico = _context.CasosJuridicos.Find(id);
        if (_casoJuridico == null) return null;

        var _casoJuridicoViewModel = new CasoJuridicoViewModel
        {
            CasoJuridicoId = _casoJuridico.CasoJuridicoId,
            Abertura = _casoJuridico.Abertura,
            Cliente = _clienteService.GetById(_casoJuridico.ClienteId),
            Advogado = _advogadoService.GetById(_casoJuridico.AdvogadoId),
            Documento = _documentoService.GetById(_casoJuridico.DocumentoId)
        };

        return _casoJuridicoViewModel;
    }

    public void Update(int Id, NewCasoJuridicoInputModel casoJuridico)
    {
        var _casoJuridico = _context.CasosJuridicos.Find(Id);
        if (_casoJuridico == null) return;
        _casoJuridico.Abertura = casoJuridico.Abertura;
        _casoJuridico.ClienteId = casoJuridico.ClienteId;
        _casoJuridico.AdvogadoId = casoJuridico.AdvogadoId;
        _casoJuridico.DocumentoId = casoJuridico.DocumentoId;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.CasosJuridicos.Remove(_context.CasosJuridicos.Find(id));
    }

   
}
