using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using Microsoft.Extensions.Configuration;
namespace GestaoDispositivos.App.Validations.Admin.Register;
public interface IRegisterAdminValidation
{
    Task<ResponseAdmin> Execute(RequestAdmin request);
}
