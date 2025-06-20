using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Exception.ExceptionBase;
using GestaoDispositivos.Exception;

namespace GestaoDispositivos.App.Validations.Users.ChangePassword;
public class ChangePasswordValidation(IClienteLogado loggedUser,
    IPasswordEncripter passwordEncripter,
    IClienteUpdate repos,
    IUnitOfWork unitOfWork
        ) : IChangePasswordValidation
{
    private readonly IClienteLogado _loggedUser = loggedUser;
    private readonly IPasswordEncripter _passwordEncripter = passwordEncripter;
    private readonly IClienteUpdate _repos = repos;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
  
    public async Task Execute(RequestChangePassword request)
    {
        var loggedUser = await _loggedUser.Get();
        Validate(request, loggedUser);

        var user = await _repos.GetById(loggedUser.Id);
        user.Senha = _passwordEncripter.Encrypt(request.NewPassword);

        _repos.Update(user);
        await _unitOfWork.Commit();
    }

    private void Validate(RequestChangePassword request, Domain.Entities.Cliente loggedUser)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(request);
        var passwordMatch = _passwordEncripter.Verify(request.Password, loggedUser.Senha);
      
        if (passwordMatch == false)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.Different_Password));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    }
}