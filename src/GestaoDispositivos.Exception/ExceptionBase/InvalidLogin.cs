using System.Net;

namespace GestaoDispositivos.Exception.ExceptionBase;
public class InvalidLogin : GestaoDispositivosException
{
    public InvalidLogin() : base(ResourceErrorMessages.Invalid_Login)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}