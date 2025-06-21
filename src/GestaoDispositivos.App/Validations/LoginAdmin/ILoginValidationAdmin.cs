using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.Extensions.Configuration;

namespace GestaoDispositivos.App.Validations.LoginAdmin;
public interface ILoginValidationAdmin
{
    Task<ResponseUser> Execute(RequestLogin request, IConfiguration configuration);
}
