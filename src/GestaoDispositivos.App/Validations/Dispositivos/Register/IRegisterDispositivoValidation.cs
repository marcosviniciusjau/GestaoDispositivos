using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Dispositivos.Register;
public interface IRegisterDispositivoValidation
{
    Task<ResponseDispositivo> Execute(RequestDispositivo request);
}
