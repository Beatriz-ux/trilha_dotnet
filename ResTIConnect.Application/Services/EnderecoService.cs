using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResTIConnect.Application.Services;

public class EnderecoService : IEnderecoService
{
    private readonly AppDbContext _context;

    public EnderecoService(AppDbContext context)
    {
        _context = context;
    }

    public List<EnderecoViewModel> GetAll()
    {
        var enderecos = _context.Enderecos.ToList();
        return enderecos.Select(e => GetById(e.EnderecoId) ?? new EnderecoViewModel()).ToList();
    }

    public EnderecoViewModel? GetById(int id)
    {
        var endereco = _context.Enderecos.Include(e => e.Usuarios).FirstOrDefault(e => e.EnderecoId == id);
        if (endereco == null)
        {
            return null;
        }

        return new EnderecoViewModel
        {
            EnderecoId = endereco.EnderecoId,
            EnderecoCompleto = $"{endereco.Logradouro}, {endereco.Numero}, {endereco.Cidade}, {endereco.Estado}",
            UsuariosId = endereco.Usuarios != null ? endereco.Usuarios.Select(u => u.UsuarioId).ToList() : new List<int>(9999)
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
            Pais = endereco.Pais,
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
        var endereco = _context.Enderecos.Include(e => e.Usuarios).FirstOrDefault(e => e.EnderecoId == id);//ao usar um ICollection, o Include é necessário pois o EF não carrega automaticamente os dados relacionados
        if (endereco == null)
        {
            throw new Exception("Endereço não encontrado");
        }
        if (endereco.Usuarios != null && endereco.Usuarios.Count > 0)
        {
            throw new Exception("Endereço não pode ser excluído pois está associado a um ou mais usuários");
        }
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
    }

    public EnderecoUserViewModel? GetByIdWithoutUsers(int id)
    {
       var endereco = _context.Enderecos.Include(e => e.Usuarios).FirstOrDefault(e => e.EnderecoId == id);
        if (endereco == null)
        {
            return null;
        }

        return new EnderecoUserViewModel
        {
            EnderecoId = endereco.EnderecoId,
            EnderecoCompleto = $"{endereco.Logradouro}, {endereco.Numero}, {endereco.Cidade}, {endereco.Estado}"
        };
    }


}
