using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services;

public class RelatoriosService
{
    private readonly AppDbContext _context;
    private readonly IUsuarioService _usuarioService;
    private readonly ISistemaService _sistemaService;
    public RelatoriosService(AppDbContext context, IUsuarioService usuarioService, ISistemaService sistemaService)
    {
        _context = context;
        _usuarioService = usuarioService;
        _sistemaService = sistemaService;
    }
    
    public ICollection<UsuarioViewModel> UserFilterByProfile(int profileId)
    {
        var users = _context.Usuarios.Include(u => u.Perfis).Where(u => u.Perfis.Any(p => p.PerfilId == profileId)).ToList();
        List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

        foreach (var usuario in users)
        {
            try
            {
                var user = _usuarioService.GetById(usuario.UsuarioId);
                if (user != null)
                    lista.Add(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        return lista;
        
    }

    public ICollection<UsuarioViewModel> UserFilterByState(string state)
    {
        var users = _context.Usuarios.Include(u => u.Endereco).Where(u => u.Endereco.Estado == state).ToList();
        List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

        foreach (var usuario in users)
        {
            try
            {
                var user = _usuarioService.GetById(usuario.UsuarioId);
                if (user != null)
                    lista.Add(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        return lista;
    }

    public ICollection<SistemaViewModel> SystemsFilterByUser(int userId){
        var systems = _context.Sistemas.Include(s => s.Usuarios).Where(s => s.Usuarios.Any(u => u.UsuarioId == userId)).ToList();
        List<SistemaViewModel> lista = new List<SistemaViewModel>();

        foreach (var sistema in systems)
        {
            try
            {
                var sys = _sistemaService.GetById(sistema.SistemaId);
                if (sys != null)
                    lista.Add(sys);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        return lista;
    }

    public ICollection<SistemaViewModel> SystemsFilterByEventTypeFromDate(string type, String date){
        var dataFormatada = DateTime.Parse(date, new CultureInfo("pt-BR"));
        var dataAtual = DateTime.Now;
        var systems = _context.Sistemas.Include(s => s.Eventos).Where(s => s.Eventos.Any(e => e.Tipo == type && e.DataHoraOcorrencia >= dataFormatada && e.DataHoraOcorrencia<= dataAtual)).ToList();
        List<SistemaViewModel> lista = new List<SistemaViewModel>();

        foreach (var sistema in systems)
        {
            try
            {
                var sys = _sistemaService.GetById(sistema.SistemaId);
                if (sys != null)
                    lista.Add(sys);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        return lista;
    }
    

}
