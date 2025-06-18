using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Dispositivos.GetAll;
public interface IGetAllDispositivoValidation
{
    Task<ResponseDispositivo> Execute();
}
