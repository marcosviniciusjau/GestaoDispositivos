using System.Net;

namespace GestaoDispositivos.Exception.ExceptionBase;

public class DispositivoInUse : GestaoDispositivosException
{

    public DispositivoInUse(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
