using GestaoDispositivos.Communication.Requests;

namespace GestaoDispositivos.App.Validations.Eventos.Update;
public interface IUpdateEventoValidation
{
    public Task Execute(Guid id, RequestUpdateEvento request);
}
