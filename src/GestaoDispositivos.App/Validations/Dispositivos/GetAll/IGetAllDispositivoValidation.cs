using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Dispositivos.GetAll;
public interface IGetAllDispositivosValidation
{
    Task<ResponseDispositivos> Execute();
}
