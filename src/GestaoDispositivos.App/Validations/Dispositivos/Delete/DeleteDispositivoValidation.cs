using AutoMapper;
using GestaoDispositivos.App.Validations.Clientes.Delete;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Dispositivos.Delete;
public class DeleteDispositivoValidation : IDeleteDispositivoValidation
{

    private readonly IClienteLogado _loggedUser;
    private readonly IDispositivoRead _dispositivoReadOnly;
    private readonly IDispositivoDelete _repos;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDispositivoValidation(
        IClienteLogado loggedUser,
        IDispositivoDelete repos,
        IDispositivoRead dispositivoReadOnly,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _dispositivoReadOnly = dispositivoReadOnly;
        _repos = repos;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var user = await _loggedUser.Get();
        var dispositivoId = await _dispositivoReadOnly.GetById(user, id);
        if (dispositivoId is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Dispositivo_Not_Found);

        }
        await _repos.Delete(id);

        await _unitOfWork.Commit();
    }
}