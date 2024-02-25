using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Financa.Application.Services;

public class ContaService : IContaService
{
    private readonly AppDbContext _context;

    public ContaService(AppDbContext context)
    {
        _context = context;
    }

    public List<ContaViewModel> GetAll()
    {
        var contas = _context.Contas.ToList();
        List<ContaViewModel> contasViewModels = new List<ContaViewModel>();

        foreach (var conta in contas)
        {
            contasViewModels.Add(GetById(conta.IdConta));
        }

        return contasViewModels;
    }

    public ContaViewModel GetById(int id)
    {
        var contasEncontrada = _context.Contas.FirstOrDefault(c => c.IdConta == id);

        if (contasEncontrada == null)
        {
            throw new Exception("Conta não encontrado");
        }

        var contaViewModel = new ContaViewModel
        {
            IdConta = contasEncontrada.IdConta,
            TipoConta = contasEncontrada.TipoConta,
            SaldoConta = contasEncontrada.SaldoConta,
            CustosFixos = contasEncontrada.CustosFixos,
            CustosVariaveis = contasEncontrada.CustosVariaveis,
            Transacoes = contasEncontrada.Transacoes,
            Investimentos = contasEncontrada.Investimentos
        };

        return contaViewModel;
    }

    public int Create(NewContaInputModel model)
    {
        /* Obs: adicionar algumas validações */
        var conta = new Conta
        {
            TipoConta =  model.TipoConta,
            SaldoConta = model.SaldoConta,
            CustosFixos = model.CustosFixos,
            CustosVariaveis = model.CustosVariaveis,
            Transacoes = model.Transacoes,
            Investimentos = model.Investimentos
        };

        _context.Contas.Add(conta);
        _context.SaveChanges();

        return conta.IdConta;
    }

    public void Update(int id, NewContaInputModel model)
    {
        var conta = _context.Contas.FirstOrDefault(c => c.IdConta == id);

        if (conta == null)
        {
            throw new Exception("Conta não encontrada");
        }

        conta.TipoConta =  model.TipoConta;
        conta.SaldoConta =  model.SaldoConta;
        conta.CustosFixos =  model.CustosFixos;
        conta.CustosVariaveis =  model.CustosVariaveis;
        conta.Transacoes =  model.Transacoes;
        conta.Investimentos =  model.Investimentos;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var conta = _context.Contas.FirstOrDefault(c => c.IdConta == id);

        if (conta == null)
        {
            throw new Exception("Conta não encontrada");
        }

        _context.Contas.Remove(conta);
        _context.SaveChanges();
    }
}
