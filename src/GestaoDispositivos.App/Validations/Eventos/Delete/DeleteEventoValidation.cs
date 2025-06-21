using AutoMapper;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;
using Microsoft.SqlServer.Management.Smo;

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
        var eventoId = await _eventoReadOnly.GetById(id);
        if (eventoId is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Evento_Not_Found);

        }
        await _repos.Delete(id);

        await _unitOfWork.Commit();
    }
}