using ResTIConnect.Application.Services.InputModels;
using ResTIConnect.Application.Services.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces;
public interface IEventoService
{
    public List<EventoViewModel> GetAll();
    public EventoViewModel? GetById(int id);
    public int Create(NewEventosInputModel evento);
    public void Update(int id, NewEventosInputModel evento);
    public void Delete(int id);
    public void AddSistema(NewEventoSistemaInputModel inputModel);
    public void RemoveSistema(NewEventoSistemaInputModel inputModel);

}
