using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ResTIConnect.Application.Services.ViewModels;
using ResTIConnect.Application.Services.InputModels;

namespace ResTIConnect.Application.Services;

public class EventoService : IEventoService
{
    private readonly AppDbContext _context;

    private readonly ISistemaService _sistemaService;

    public EventoService(AppDbContext context, ISistemaService sistemaService)
    {
        _context = context;
        _sistemaService = sistemaService;
    }

    public List<EventoViewModel> GetAll()
    {
        var eventos = _context.Eventos.ToList();

        return eventos.Select(e => GetById(e.EventoId) ?? new EventoViewModel()).ToList();
    }

    public EventoViewModel? GetById(int id)
    {
        var evento = _context.Eventos.Include(e => e.Sistemas).FirstOrDefault(e => e.EventoId == id);
        if (evento == null)
        {
            return null;
        }

        return new EventoViewModel
        {
            Id = evento.EventoId,
            Tipo = evento.Tipo,
            Descricao = evento.Descricao,
            Codigo = evento.Codigo,
            Conteudo = evento.Conteudo,
            DataHoraOcorrencia = evento.DataHoraOcorrencia,
            SistemasId = evento.Sistemas != null ? evento.Sistemas.Select(s => s.SistemaId).ToList() : new List<int>()
        };
    }

    public int Create(NewEventosInputModel evento)
    {
        if (evento.Sistemas == null)
        {
            throw new Exception("Sistema(s) não informado(s)");
        }
        var sistemasEncontrados = evento.Sistemas.Select(id => _context.Sistemas.Find(id));
        var sistemasExistentes = sistemasEncontrados.Where(s => s != null).ToList() as List<Sistema>;

        if (sistemasExistentes.Count != evento.Sistemas.Count)
        {
            throw new Exception("Sistema(s) não encontrado(s)");
        }

        var novoEvento = new Eventos
        {
            Tipo = evento.Tipo,
            Descricao = evento.Descricao,
            Codigo = evento.Codigo,
            Conteudo = evento.Conteudo,
            DataHoraOcorrencia = evento.DataHoraOcorrencia,
            Sistemas = sistemasExistentes

        };

        _context.Eventos.Add(novoEvento);
        _context.SaveChanges();
        return novoEvento.EventoId;
    }

    public void Update(int id, NewEventosInputModel evento)
    {
        var eventoToUpdate = _context.Eventos.FirstOrDefault(e => e.EventoId == id);
        if (eventoToUpdate == null)
        {
            throw new Exception("Evento não encontrado");
        }


        eventoToUpdate.Tipo = evento.Tipo;
        eventoToUpdate.Descricao = evento.Descricao;
        eventoToUpdate.Codigo = evento.Codigo;
        eventoToUpdate.Conteudo = evento.Conteudo;
        eventoToUpdate.DataHoraOcorrencia = evento.DataHoraOcorrencia;

        if (evento.Sistemas != null)
        {
            var sistemasEncontrados = evento.Sistemas.Select(id => _context.Sistemas.Find(id));
            var sistemasExistentes = sistemasEncontrados.Where(s => s != null).ToList() as List<Sistema>;

            eventoToUpdate.Sistemas = sistemasExistentes;


        }

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var eventoToDelete = _context.Eventos.FirstOrDefault(e => e.EventoId == id);
        if (eventoToDelete == null)
        {
            throw new Exception("Evento não encontrado");
        }

        _context.Eventos.Remove(eventoToDelete);
        _context.SaveChanges();
    }


    public void AddSistema(NewEventoSistemaInputModel inputModel)
    {
        var evento = _context.Eventos.Include(e => e.Sistemas).FirstOrDefault(e => e.EventoId == inputModel.EventoId);
        if (evento == null)
        {
            throw new Exception("Evento não encontrado");
        }

        var sistema = _context.Sistemas.Find(inputModel.SistemaId);
        if (sistema == null)
        {
            throw new Exception("Sistema não encontrado");
        }

        evento.Sistemas.Add(sistema);
        _context.SaveChanges();
    }

    public void RemoveSistema(NewEventoSistemaInputModel inputModel)
    {
        var evento = _context.Eventos.Include(e => e.Sistemas).FirstOrDefault(e => e.EventoId == inputModel.EventoId);
        if (evento == null)
        {
            throw new Exception("Evento não encontrado");
        }

        var sistema = _context.Sistemas.Find(inputModel.SistemaId);
        if (sistema == null)
        {
            throw new Exception("Sistema não encontrado");
        }

        evento.Sistemas.Remove(sistema);
        _context.SaveChanges();
    }


}
