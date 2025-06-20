using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Eventos.GetAll;
public interface IGetAllEventosValidation
{
    Task<EventosByTipo> Execute();
}
