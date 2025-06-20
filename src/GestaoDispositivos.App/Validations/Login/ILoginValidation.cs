using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;

namespace GestaoDispositivos.App.Validations.Login;
public interface ILoginValidation
{
    Task<ResponseUser> Execute(RequestLogin request);
}
