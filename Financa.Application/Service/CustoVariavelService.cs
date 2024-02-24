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
    public class CustoVariavelService : ICustoVariavelService
    {
        private readonly AppDbContext _context;

        public CustoVariavelService(AppDbContext context)
        {
            _context = context;
        }


        public int Create(NewCustoVariavelModelInputModel newCustoVariavel)
        {
            var custoVariavel = new CustoVariavel
            {
                ValorVariavel = newCustoVariavel.ValorVariavel,
                IdConta = newCustoVariavel.IdConta,
                IdCategoria = newCustoVariavel.IdCategoria,

            };
            _context.CustoVariaveis.Add(custoVariavel);
            _context.SaveChanges();
            return custoVariavel.IdCustoVariavel;
        }

        public void Delete(int id)
        {
            var custoVariavel = _context.CustoVariaveis.Find(id);
            _context.CustoVariaveis.Remove(custoVariavel);
            _context.SaveChanges();
        }

        public List<CustoVariavelViewModel> GetAll()
        {
            var custosVariaveis = _context.CustoVariaveis
            .Select(c => new CustoVariavelViewModel
            {
                ValorVariavel = c.ValorVariavel,
                IdConta = c.IdConta,
                IdCategoria = c.IdCategoria,
                Conta = c.Conta
            })
            .ToList();
            return custosVariaveis;
        }

        public CustoVariavelViewModel GetById(int id)
        {
            var custoVariavel = _context.CustoVariaveis
             .Where(c => c.IdCustoVariavel == id)
             .Select(c => new CustoVariavelViewModel
             {
                 ValorVariavel = c.ValorVariavel,
                 IdConta = c.IdConta,
                 IdCategoria = c.IdCategoria,
                 Conta = c.Conta
             })
             .FirstOrDefault();
            if (custoVariavel == null)
            {
                throw new Exception("Custo variável não encontrado");
            }
            return custoVariavel;
        }

        public void Update(int id, NewCustoVariavelModelInputModel newCustoVariavel)
        {
            var custoVariavel = _context.CustoVariaveis.Find(id);
            if (custoVariavel == null)
            {
                throw new Exception("Custo variável não encontrado");
            }
            custoVariavel.ValorVariavel = newCustoVariavel.ValorVariavel;
            _context.SaveChanges();
        }
    }
}