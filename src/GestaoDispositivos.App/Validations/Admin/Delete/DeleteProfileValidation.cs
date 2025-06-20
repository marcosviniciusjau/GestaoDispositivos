using AutoMapper;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Admin;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Admin.Delete;
public class DeleteProfileValidation : IDeleteProfileValidation
{

    private readonly IAdminLogado _loggedUser;
    private readonly IAdminDelete _repos;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfileValidation(
        IAdminLogado loggedUser,
        IAdminDelete repos,
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