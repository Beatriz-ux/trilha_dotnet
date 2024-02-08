using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financa.Core.Entities;

namespace Financa.Core.Interfaces
{
    public interface ICustoVariavelCollection : IBaseCollection<CustoVariavel>
    {
        void Update(CustoVariavel entity);
    }
   
}