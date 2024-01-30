using TechAdvocacia.Infrastructure.Persistence.Interfaces;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence;

public class AdvogadoDB : IAdvogado
{
    private readonly List<Advogado> _advogados = new List<Advogado>();
    private int _id = 1;

    public int Create(Advogado advogado)
    {
        if (_advogados.Count > 0)
        {
            _id = _advogados.Max(x => x.AdvogadoId);
        }
        advogado.AdvogadoId = _id++;
        _advogados.Add(advogado);

        return advogado.AdvogadoId;
    }

    public void Delete(int id)
    {
        _advogados.RemoveAll(x => x.AdvogadoId == id);
    }

    public ICollection<Advogado> GetAll()
    {
        return _advogados.ToArray();
    }

    public Advogado? GetById(int id)
    {
        return _advogados.FirstOrDefault(x => x.AdvogadoId == id);
    }

    public void Update(Advogado advogado, int id)
    {
        var novoAdvogado = _advogados.FirstOrDefault(x => x.AdvogadoId == id);
        if (novoAdvogado is not null)
            novoAdvogado.Nome = advogado.Nome;
    }

}
