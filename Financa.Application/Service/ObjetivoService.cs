using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Financa.Application.Services;

public class ObjetivoService : IObjetivoService
{
    private readonly AppDbContext _context;

    public ObjetivoService(AppDbContext context)
    {
        _context = context;
    }

    public List<ObjetivoViewModel> GetAll()
    {
        var objetivos = _context.Objetivo
            .Include(o => o.Investimentos)
            .Select(o => new ObjetivoViewModel
            {
                IdObjetivo = o.Id,
                Nome = o.Nome,
                Investimentos = o.Investimentos.Select(i => i.IdInvestimento).ToList()
            })
            .ToList();

        return objetivos;
    }

    public ObjetivoViewModel GetById(int id)
    {
        var objetivo = _context.Objetivo
            .Include(o => o.Investimentos)
            .FirstOrDefault(o => o.Id == id);

        if (objetivo == null)
        {
            return null;
        }

        var objetivoViewModel = new ObjetivoViewModel
        {
            IdObjetivo = objetivo.Id,
            Nome = objetivo.Nome,
            Investimentos = objetivo.Investimentos.Select(i => i.IdInvestimento).ToList()
        };

        return objetivoViewModel;
    }

    public int Create(NewObjetivoInputModel model)
    {
        // if(model.Investimentos == null)
        // {
        //     model.Investimentos = new List<int>();
        //    // throw new Exception("Investimentos não podem ser nulos");
        // }
        
        var objetivo = new Objetivo
        {
            Nome = model.Nome,
            Investimentos = new List<Investimento>()
        };

        _context.Objetivo.Add(objetivo);
        _context.SaveChanges();

        return objetivo.Id;
    }

    public void Update(int id, NewObjetivoInputModel model)
    {
        var objetivo = _context.Objetivo
            .Include(o => o.Investimentos)
            .FirstOrDefault(o => o.Id == id);

        if (objetivo == null)
        {
            throw new Exception("Objetivo não encontrado");
        }

        objetivo.Nome = model.Nome;

        // if (model.Investimentos != null)
        // {
        //     var InvestimentosEncontrados = _context.Investimentos.Include(i => i.Objetivos).Where(i => model.Investimentos.Contains(i.IdInvestimento)).ToList();
        //     objetivo.Investimentos = InvestimentosEncontrados;
        // }

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var objetivo = _context.Objetivo
            .Include(o => o.Investimentos)
            .FirstOrDefault(o => o.Id == id);

        if (objetivo == null)
        {
            throw new Exception("Objetivo não encontrado");
        }

        _context.Objetivo.Remove(objetivo);
        _context.SaveChanges();
    }

}
