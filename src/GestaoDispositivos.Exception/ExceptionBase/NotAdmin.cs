using System.Net;

namespace GestaoDispositivos.Exception.ExceptionBase;
public class NotAdmin : GestaoDispositivosException
{
    public NotAdmin() : base(ResourceErrorMessages.Not_Admin)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}