using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Exception.ExceptionBase;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Domain.Repos;
namespace GestaoDispositivos.App.Validations.Clientes.Update;
public class UpdateProfileValidation(
    IClienteUpdate repos,
    IClienteLogado loggedUser,
    IUnitOfWork unitOfWork
 ) : IUpdateProfileValidation
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClienteLogado _loggedUser = loggedUser;
    private readonly IClienteUpdate _repos = repos;
    public async Task Execute(RequestUpdateProfile request)
    {
        var loggedUser = await _loggedUser.Get();
        await Validate(request, loggedUser.Email);

        var cliente = await _repos.GetById(loggedUser.Id);
        cliente.Nome = request.Nome;
        cliente.Telefone = request.Telefone;
        cliente.Email = request.Email;


        _repos.Update(cliente);

        await _unitOfWork.Commit();
    }

    private async Task Validate(RequestUpdateProfile request, string currentEmail)
    {
        var validator = new UpdateProfileValidator();

        var result = validator.Validate(request);
        if (currentEmail.Equals(request.Email) == false)
        {
            var userExist = await _repos.Exists(request.Email);
            if (userExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.Email_Exists));
            }
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    }
}