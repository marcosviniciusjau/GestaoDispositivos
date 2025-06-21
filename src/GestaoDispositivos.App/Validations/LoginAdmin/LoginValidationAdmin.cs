using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Admin;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Exception.ExceptionBase;
using Microsoft.Extensions.Configuration;

namespace GestaoDispositivos.App.Validations.LoginAdmin;
public class LoginValidationAdmin : ILoginValidationAdmin
{
    private readonly IAdminRead _repos;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginValidationAdmin(IAdminRead repos, IPasswordEncripter passwordEncripter, ITokenGenerator tokenGenerator)
    {
        _repos = repos;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseUser> Execute(RequestLogin request, IConfiguration configuration)
    {

        var adminEmail = configuration.GetValue<string>("Settings:AdminEmail");
        if (adminEmail != request.Email) throw new NotAdmin();
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
            Token = _tokenGenerator.GenerateAdmin(user)
        };
    }
}
