using AutoMapper;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Eventos.Delete;
public class DeleteEventoValidation : IDeleteEventoValidation
{

    private readonly IClienteLogado _loggedUser;
    private readonly IEventoRead _eventoReadOnly;
    private readonly IEventoDelete _repos;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEventoValidation(
        IClienteLogado loggedUser,
        IEventoDelete repos,
        IEventoRead eventoReadOnly,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _eventoReadOnly = eventoReadOnly;
        _repos = repos;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var dispositivoId = await _eventoReadOnly.GetById( id);
        if (dispositivoId is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Dispositivo_Not_Found);

        }
        await _repos.Delete(id);

        await _unitOfWork.Commit();
    }
}