using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence.Interfaces;
namespace TechAdvocacia.Infrastructure.Persistence;

public class DocumentoDB : IDocumento
{
    private readonly List<Documento> _documentos = new List<Documento>();
    private int _id=1;

    public int Create(Documento documento)
    {
        if (_documentos.Count > 0)
        {
            _id = _documentos.Max(x => x.DocumentoId);
        }
        documento.DocumentoId = _id++;
        documento.DataHora = DateTime.Now;
        documento.Codigo = new Random().Next();
        documento.Descricao = "Documento";
        _documentos.Add(documento);

        return documento.DocumentoId;
    }

    public void Delete(int id)
    {
        _documentos.RemoveAll(x => x.DocumentoId == id);
    }

    public ICollection<Documento> GetAll()
    {
        return _documentos.ToArray();
    }

    public Documento? GetById(int id)
    {
        return _documentos.FirstOrDefault(x => x.DocumentoId == id);
    }

    public void Update(Documento documento, int id)
    {
        var novoDocumento = _documentos.FirstOrDefault(x => x.DocumentoId == id);
        if(novoDocumento is not null)
        novoDocumento.Descricao = documento.Descricao;
    }
}

    