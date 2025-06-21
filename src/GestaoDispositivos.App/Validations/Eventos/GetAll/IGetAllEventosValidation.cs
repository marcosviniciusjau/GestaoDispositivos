using GestaoDispositivos.Domain.Entities;
namespace GestaoDispositivos.App.Validations.Eventos.GetAll;
public interface IGetAllEventosValidation
{
    Task<List<EventosByTipo>> Execute();
}
