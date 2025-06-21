using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Clientes.GetProfile;
public interface IGetProfileValidation
{
    public Task<ResponseClienteProfile> Execute();
}
