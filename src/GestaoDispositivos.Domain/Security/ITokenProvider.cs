namespace GestaoDispositivos.Domain.Security;
public interface ITokenProvider
{
    string TokenOnRequest();
}