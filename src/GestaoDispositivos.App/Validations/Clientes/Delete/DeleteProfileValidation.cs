using AutoMapper;
using GestaoDispositivos.App.Validations.Admin.Delete;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Clientes.Delete;
public class DeleteProfileValidation : IDeleteProfileValidation
{

    private readonly IClienteLogado _loggedUser;
    private readonly IClienteDelete _repos;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfileValidation(
        IClienteLogado loggedUser,
        IClienteDelete repos,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _repos = repos;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute()
    {
        var user = await _loggedUser.Get();

        await _repos.Delete(user);

        await _unitOfWork.Commit();
    }
}