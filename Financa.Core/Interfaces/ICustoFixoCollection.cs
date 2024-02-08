using Financa.Core.Entities;

namespace Financa.Core.Interfaces
{
    public interface ICustoFixoCollection : IBaseCollection<CustoFixo>
    {
        void Update(CustoFixo entity);
    }
}
