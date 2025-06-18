using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Eventos.Register;
public interface IRegisterEventoValidation
{
    Task<ResponseEvento> Execute(RequestEvento request);
}
