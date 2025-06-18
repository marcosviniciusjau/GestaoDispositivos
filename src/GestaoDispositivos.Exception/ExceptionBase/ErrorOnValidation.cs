using System.Net;

namespace GestaoDispositivos.Exception.ExceptionBase;
public class ErrorOnValidation : GestaoDispositivosException
{
    private readonly List<string> _errors;
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public ErrorOnValidation(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}