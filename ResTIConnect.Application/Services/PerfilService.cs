using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Application.Services
{
    public class PerfilService : IPerfilService

    {

        private readonly AppDbContext _context;
        public PerfilService(AppDbContext context)
        {
            _context = context;
        }
        public int Create(NewPerfilInputModel perfil)
        {

            var _perfil = new Perfil
            {
                Descricao = perfil.Descricao,
                Permissoes = perfil.Permissoes

            };

            if (perfil.UsuarioId != null)
            {
                var usuarioEncontrado = _context.Usuarios.Find(perfil.UsuarioId);
                if (usuarioEncontrado != null)
                {
                    _perfil.UsuarioId = perfil.UsuarioId;
                    _perfil.Usuario = usuarioEncontrado;
                }else
                {
                    throw new Exception("Usuário não encontrado");
                }
            }
            _context.Perfis.Add(_perfil);

            _context.SaveChanges();

            return _perfil.PerfilId;
        }

        public void Delete(int id)
        {
            _context.Perfis.Remove(GetByDbId(id));

            _context.SaveChanges();
        }

        private Perfil GetByDbId(int id)
        {
            var _perfil = _context.Perfis.Find(id);

            if (_perfil is null)
                return null;

            return _perfil;
        }

        public List<PerfilViewModel> GetAll()
        {
            var _perfis = _context.Perfis.Select(m => new PerfilViewModel
            {
                PerfilId = m.PerfilId,
                Descricao = m.Descricao,
                Permissoes = m.Permissoes,
                UsuarioId = m.UsuarioId
                
            }).ToList();
           

            return _perfis;

        }

        public PerfilViewModel? GetById(int id)
        {
            var _perfil = GetByDbId(id);

            var PerfilViewModel = new PerfilViewModel
            {
                PerfilId = _perfil.PerfilId,
                Descricao = _perfil.Descricao,
                Permissoes = _perfil.Permissoes,
                UsuarioId = _perfil.UsuarioId

            };
            return PerfilViewModel;
        }

        public void Update(int id, NewPerfilInputModel perfil)
        {
            var _perfil = GetByDbId(id);

            _perfil.Descricao = perfil.Descricao;
            _perfil.Permissoes = perfil.Permissoes;

            _context.Perfis.Update(_perfil);

            _context.SaveChanges();
        }
    }
}
