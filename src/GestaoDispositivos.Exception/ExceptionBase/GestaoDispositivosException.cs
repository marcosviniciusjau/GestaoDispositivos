namespace GestaoDispositivos.Exception.ExceptionBase;
public abstract class GestaoDispositivosException : SystemException
{
 
    protected GestaoDispositivosException(string message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}