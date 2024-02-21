using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Financa.Application.Services;

public class InvestimentoService : IInvestimentoService
{
   private readonly AppDbContext _context;

    public InvestimentoService(AppDbContext context)
    {
        _context = context;
    }

    public List<InvestimentoViewModel> GetAll()
    {
        var investimentos = _context.Investimentos.Include(i => i.Objetivos).ToList();
        List<InvestimentoViewModel> investimentosViewModel = new List<InvestimentoViewModel>();

        foreach (var investimento in investimentos)
        {
            investimentosViewModel.Add(GetById(investimento.IdInvestimento));
        }

        return investimentosViewModel;
    }

    public InvestimentoViewModel GetById(int id)
    {
        var objetivosEncontrados = _context.Objetivo.Where(o => o.Investimentos.Any(i => i.IdInvestimento == id)).ToList();

        var investimento = _context.Investimentos
            .Include(i => i.Objetivos)
            .FirstOrDefault(i => i.IdInvestimento == id);

        if (investimento == null)
        {
            throw new Exception("Investimento não encontrado");
        }
        if (objetivosEncontrados == null)
        {
            throw new Exception("Objetivos não encontrados");
        }

        var investimentoViewModel = new InvestimentoViewModel
        {
            IdInvestimento = investimento.IdInvestimento,
            Nome = investimento.Nome,
            ValorInvestido = investimento.ValorInvestido,
            DataCompra = investimento.DataCompra,
            TaxaDeRetorno = investimento.TaxaDeRetorno,
            IdConta = investimento.IdConta,
            NomesObjetivos = objetivosEncontrados.Select(o => o.Nome).ToList()
        };

        return investimentoViewModel;
    }

    public int Create(NewInvestimentoInputModel model)
    {
        ICollection<Objetivo> objetivos = new List<Objetivo>();
        foreach (var idObj in model.Objetivos)
        {
            objetivos.Add(_context.Objetivo.Find(idObj) ?? throw new Exception("Objetivo não encontrado"));
        }
        if(model.Objetivos == null)
        {
            throw new Exception("Objetivos não podem ser nulos");
        }
        if(objetivos == null)
        {
            throw new Exception("Objetivos não podem ser vazios");
        }
        
        var investimento = new Investimento
        {
            Nome = model.Nome,
            ValorInvestido = model.ValorInvestido,
            DataCompra = model.DataCompra,
            TaxaDeRetorno = model.TaxaDeRetorno,
            IdConta = model.IdConta,
            Objetivos = objetivos
        };

        _context.Investimentos.Add(investimento);
        _context.SaveChanges();

        return investimento.IdInvestimento;
    }

    public void Update(int id, NewInvestimentoInputModel model)
    {
        var investimento = _context.Investimentos.Find(id) ?? throw new Exception("Investimento não encontrado");

        ICollection<Objetivo> objetivos = new List<Objetivo>();
        foreach (var idObj in model.Objetivos)
        {
            objetivos.Add(_context.Objetivo.Find(idObj) ?? throw new Exception("Objetivo não encontrado"));
        }
        if(model.Objetivos == null)
        {
            throw new Exception("Objetivos não podem ser nulos");
        }
        if(objetivos == null)
        {
            throw new Exception("Objetivos não podem ser vazios");
        }

        investimento.Nome = model.Nome;
        investimento.ValorInvestido = model.ValorInvestido;
        investimento.DataCompra = model.DataCompra;
        investimento.TaxaDeRetorno = model.TaxaDeRetorno;
        investimento.IdConta = model.IdConta;
        investimento.Objetivos = objetivos;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var investimento = _context.Investimentos.Find(id) ?? throw new Exception("Investimento não encontrado");

        _context.Investimentos.Remove(investimento);
        _context.SaveChanges();
    }

}
