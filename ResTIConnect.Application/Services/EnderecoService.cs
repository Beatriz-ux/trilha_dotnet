using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services;

public class EnderecoService : IEnderecoService
{
    private readonly  AppDbContext _context;

    public EnderecoService(AppDbContext context)
    {
        _context = context;
    }

    public List<EnderecoViewModel> GetAll()
    {
        var enderecos = _context.Enderecos.ToList();
        return enderecos.Select(e => new EnderecoViewModel
        {
            EnderecoId = e.EnderecoId,
            EnderecoCompleto = $"{e.Logradouro}, {e.Numero}, {e.Cidade}, {e.Estado}"
        }).ToList();
    }

    public EnderecoViewModel? GetById(int id)
    {
        var endereco = _context.Enderecos.Find(id);
        if (endereco == null)
        {
            return null;
        }
        return new EnderecoViewModel
        {
            EnderecoId = endereco.EnderecoId,
            EnderecoCompleto = $"{endereco.Logradouro}, {endereco.Numero}, {endereco.Cidade}, {endereco.Estado}"
        };
    }

    public int Create(NewEnderecoInputModel endereco)
    {
        var novoEndereco = new Endereco
        {
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero,
            Cidade = endereco.Cidade,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Estado = endereco.Estado,
            Cep = endereco.Cep,
            Pais = endereco.Pais
        };
        _context.Enderecos.Add(novoEndereco);
        _context.SaveChanges();
        return novoEndereco.EnderecoId;
    }

    public void Update(int id, NewEnderecoInputModel endereco)
    {
        var enderecoAtual = _context.Enderecos.Find(id);
        if (enderecoAtual == null)
        {
            throw new Exception("Endereço não encontrado");
        }
        enderecoAtual.Logradouro = endereco.Logradouro;
        enderecoAtual.Numero = endereco.Numero;
        enderecoAtual.Cidade = endereco.Cidade;
        enderecoAtual.Complemento = endereco.Complemento;
        enderecoAtual.Bairro = endereco.Bairro;
        enderecoAtual.Estado = endereco.Estado;
        enderecoAtual.Cep = endereco.Cep;
        enderecoAtual.Pais = endereco.Pais;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var endereco = _context.Enderecos.Find(id);
        if (endereco == null)
        {
            throw new Exception("Endereço não encontrado");
        }
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
    }

}
