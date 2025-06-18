using System.Net;

namespace GestaoDispositivos.Exception.ExceptionBase;

public class NotFoundException : GestaoDispositivosException
{

    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
