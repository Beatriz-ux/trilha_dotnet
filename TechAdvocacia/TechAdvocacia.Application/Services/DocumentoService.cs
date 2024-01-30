using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Infrastructure.Persistence;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services;

public class DocumentoService : IDocumentoService
{
    private readonly TechAdvocaciaDbContext _dbContext;

    public DocumentoService(TechAdvocaciaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<DocumentoViewModel> GetAll()
    {
        var documentos = _dbContext.Documentos.ToList();

        var documentosViewModel = documentos.Select(d => new DocumentoViewModel
        {
            DocumentoId = d.DocumentoId,
            Descricao = d.Descricao
        }).ToList();

        return documentosViewModel;
    }

    public DocumentoViewModel? GetById(int id)
    {
        var documento = _dbContext.Documentos.SingleOrDefault(d => d.DocumentoId == id);

        if (documento == null)
        {
            return null;
        }

        var documentoViewModel = new DocumentoViewModel
        {
            DocumentoId = documento.DocumentoId,
            Descricao = documento.Descricao
        };

        return documentoViewModel;
    }

    public int Create(NewDocumentoInputModel documento)
    {
        var newDocumento = new Documento
        {
            Descricao = documento.Descricao
        };

        _dbContext.Documentos.Add(newDocumento);
        _dbContext.SaveChanges();

        return newDocumento.DocumentoId;
    }

    public void Update(int id, NewDocumentoInputModel documento)
    {
        var documentoToUpdate = _dbContext.Documentos.SingleOrDefault(d => d.DocumentoId == id);

        if (documentoToUpdate == null)
        {
            return;
        }

        documentoToUpdate.Descricao = documento.Descricao;

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var documentoToDelete = _dbContext.Documentos.SingleOrDefault(d => d.DocumentoId == id);

        if (documentoToDelete == null)
        {
            return;
        }

        _dbContext.Documentos.Remove(documentoToDelete);
        _dbContext.SaveChanges();
    }
}
