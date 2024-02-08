using Financa.Core.Interfaces;
using Entities;

namespace Financa.Infrastructure;
    // public int IdCustoFixo { get; set; }
    // public float ValorParcelaFixo { get; set; }
    // public DateTime DataProximaParcelaFixo { get; set; }
    // public int ParcelasRestantesFixo { get; set; }
    // public int IdConta { get; set; }
    // public int IdCategoria { get; set; }
    // public Conta Conta { get; set; }

public class CustoFixoDB : ICustoFixoCollection
{
    private readonly List<CustoFixo> _custosFixos = new List<CustoFixo>();
    private int _id=0;

    public void Create(CustoFixo entity)
    {
        entity.IdCustoFixo = _id++;
        _custosFixos.Add(entity);
    }
    public ICollection<CustoFixo> GetAll()
    {
        return _custosFixos;
    }

    public CustoFixo GetById(int id)
    {
        return _custosFixos.FirstOrDefault(c => c.IdCustoFixo == id);
    }
    public void Delete(CustoFixo entity)
    {
        _custosFixos.Remove(entity);
    }

    public void Update(CustoFixo entity)
    {
        var index = _custosFixos.FindIndex(c => c.IdCustoFixo == entity.IdCustoFixo);
        _custosFixos[index] = entity;
    }
}
