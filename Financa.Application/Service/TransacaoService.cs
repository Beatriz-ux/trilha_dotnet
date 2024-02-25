using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Financa.Application.Service;

public class TransacaoService : ITransacaoService
{
    private readonly AppDbContext _context;
    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public List<TransacaoViewModel> GetAll()
    {
        var _transacoes = _context.Transacaos
        .Include(t => t.Categoria)
        .Include(t => t.Conta)
        .Select(t => new TransacaoViewModel
        {
            IdTransacao = t.IdTransacao,
            ValorTransacao = t.ValorTransacao,
            DataTransacao = t.DataTransacao,
            TipoTransacao = t.TipoTransacao,
            Conta = new ContaViewModel
            {
                IdConta = t.Conta.IdConta,
                TipoConta = t.Conta.TipoConta,
                SaldoConta = t.Conta.SaldoConta
            },
            Categoria = new CategoriaViewModel
            {
                Nome = t.Categoria.Nome
            }
        }).ToList();
        return _transacoes;
    }
    public TransacaoViewModel GetById(int id)
    {
        var transacao = _context.Transacaos
            .Include(t => t.Categoria)
            .FirstOrDefault(t => t.IdTransacao == id);
        
        if (transacao == null) throw new Exception("Transação não encontrada");
        
        return new TransacaoViewModel
        {
            IdTransacao = transacao.IdTransacao,
            ValorTransacao = transacao.ValorTransacao,
            DataTransacao = transacao.DataTransacao,
            TipoTransacao = transacao.TipoTransacao,
            Conta = new ContaViewModel
            {
                IdConta = transacao.Conta.IdConta,
                TipoConta = transacao.Conta.TipoConta,
                SaldoConta = transacao.Conta.SaldoConta
            },
            Categoria = new CategoriaViewModel
            {
                Nome = transacao.Categoria.Nome
            }
        };
    }
    public int Create(NewTransacaoInputModel model)
    {
        var transacao = new Transacao
        {
            ValorTransacao = model.ValorTransacao,
            DataTransacao = model.DataTransacao,
            TipoTransacao = model.TipoTransacao,
            IdConta = model.IdConta,
            IdCategoria = model.IdCategoria,
            Conta = _context.Contas.FirstOrDefault(c => c.IdConta == model.IdConta)!,
            Categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == model.IdCategoria)!
        };
        return transacao.IdTransacao;
    }
    public void Update(int id, NewTransacaoInputModel model)
    {
        var transacao = _context.Transacaos
            .Include(t => t.Categoria)
            .Include(t => t.Conta)
            .FirstOrDefault(t => t.IdTransacao == id);
        
        if (transacao == null) throw new Exception("Transação não encontrada");

        transacao.ValorTransacao = model.ValorTransacao;
        transacao.DataTransacao = model.DataTransacao;
        transacao.TipoTransacao = model.TipoTransacao;
        transacao.IdConta = model.IdConta;
        transacao.IdCategoria = model.IdCategoria;
        transacao.Conta = _context.Contas.FirstOrDefault(c => c.IdConta == transacao.IdConta)!;
        transacao.Categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == transacao.IdCategoria)!;

        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var transacao = _context.Transacaos
            .Include(t => t.Categoria)
            .Include(t => t.Conta)
            .FirstOrDefault(t => t.IdTransacao == id);
        
        if (transacao == null) throw new Exception("Transação não encontrada");

        _context.Transacaos.Remove(transacao);
        _context.SaveChanges();
    }
}
