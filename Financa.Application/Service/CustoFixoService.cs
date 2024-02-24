using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;

namespace Financa.Application.Service
{
    public class CustoFixoService : ICustoFixoService
    {
        private readonly AppDbContext _context;

        public CustoFixoService(AppDbContext context)
        {
            _context = context;
        }
        public int Create(NewCustoFixoInputModel newCustoFixo)
        {
            var custoFixo = new CustoFixo
            {
                ValorParcelaFixo = newCustoFixo.ValorParcelaFixo,
                DataProximaParcelaFixo = newCustoFixo.DataProximaParcelaFixo

            };
            _context.CustoFixos.Add(custoFixo);
            _context.SaveChanges();
            return custoFixo.IdCustoFixo;
        }

        public void Delete(int id)
        {
            var custoFixo = _context.CustoFixos.Find(id);
            _context.CustoFixos.Remove(custoFixo);
            _context.SaveChanges();
        }

        public List<CustoFixoViewModel> GetAll()
        {
            var custosFixos = _context.CustoFixos
            .Select(c => new CustoFixoViewModel
            {
                ValorParcelaFixo = c.ValorParcelaFixo,
                DataProximaParcelaFixo = c.DataProximaParcelaFixo,
            })
            .ToList();
            return custosFixos;
        }

        public CustoFixoViewModel GetById(int id)
        {
            var custoFixo = _context.CustoFixos
            .Where(c => c.IdCustoFixo == id)
            .Select(c => new CustoFixoViewModel
            {
                ValorParcelaFixo = c.ValorParcelaFixo,
                DataProximaParcelaFixo = c.DataProximaParcelaFixo,
            })
            .FirstOrDefault();
            if (custoFixo == null)
            {
                throw new Exception("Custo fixo não encontrado");
            }
            return custoFixo;
        }

        public void Update(int id, NewCustoFixoInputModel newCustoFixo)
        {
            var custoFixo = _context.CustoFixos.Find(id);
            if (custoFixo == null)
            {
                throw new Exception("Custo fixo não encontrado");
            }
            custoFixo.ParcelasRestantesFixo = newCustoFixo.ParcelasRestantesFixo;
            _context.SaveChanges();
        }
    }
}