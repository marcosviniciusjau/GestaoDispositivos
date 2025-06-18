using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Users.GetProfile;
public interface IGetProfileValidation
{
    public Task<ResponseClienteProfile> Execute();
}
