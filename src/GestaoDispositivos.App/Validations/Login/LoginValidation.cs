
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Login;
public class LoginValidation : ILoginValidation
{
    private readonly IClienteRead _repos;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginValidation(IClienteRead repos, IPasswordEncripter passwordEncripter, ITokenGenerator tokenGenerator)
    {
        _repos = repos;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseUser> Execute(RequestLogin request)
    {
        var user = await _repos.GetByEmail(request.Email);
        if (user is null)
        {
            throw new InvalidLogin();
        }
        var passwordMatch = _passwordEncripter.Verify(request.Senha, user.Senha);
        if(passwordMatch == false)
        {
            throw new InvalidLogin();
        }

        return new ResponseUser
        {
            Token = _tokenGenerator.Generate(user)
        };
    }
}
