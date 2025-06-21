using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Eventos.GetById;
public interface IGetEventoByIdValidation
{
    Task<ResponseEvento> Execute(Guid id);
}