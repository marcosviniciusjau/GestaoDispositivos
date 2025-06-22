using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Eventos.GetById;
public interface IGetByIdValidation
{
    Task<ResponseEvento> Execute(Guid id);
}