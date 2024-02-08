using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financa.Core.Entities;
using Financa.Core.Interfaces;

namespace Financa.Infrastructure.Persistence.DataBase
{
    public class CustoVariavelDB : ICustoVariavelCollection
    {
        private readonly List<CustoVariavel> _custosVariavel = new List<CustoVariavel>();
        private int _id = 0;

        public void Create(CustoVariavel entity)
        {
            entity.IdCustoVariavel = _id++;
            _custosVariavel.Add(entity);
        }
        public ICollection<CustoVariavel> GetAll()
        {
            return _custosVariavel;
        }

        public CustoVariavel GetById(int id)
        {
            return _custosVariavel.FirstOrDefault(c => c.IdCustoVariavel == id);
        }
        public void Delete(CustoVariavel entity)
        {
            _custosVariavel.Remove(entity);
        }

        public void Update(CustoVariavel entity)
        {
            var index = _custosVariavel.FindIndex(c => c.IdCustoVariavel == entity.IdCustoVariavel);
            _custosVariavel[index] = entity;
        }
    }
}