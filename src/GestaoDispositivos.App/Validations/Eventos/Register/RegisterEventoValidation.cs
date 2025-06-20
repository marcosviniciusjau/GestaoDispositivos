using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;
using GestaoEventos.App.Validations.Eventos;
using Microsoft.SqlServer.Management.Smo;

namespace GestaoDispositivos.App.Validations.Eventos.Register;
public class RegisterEventoValidation : IRegisterEventoValidation
{
    private readonly IEventoCreate _repo;
    private readonly IEventoRead _repoRead;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public RegisterEventoValidation(
        IEventoCreate repo,
        IEventoRead repoRead,
        IUnitOfWork unityOfWork,
        IMapper mapper,
        IClienteLogado loggedUser
        )
    {
        _repo = repo; 
        _repoRead = repoRead;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseEvento> Execute(RequestEvento request)
    {
        Validate(request);
        
        var evento = _mapper.Map<Domain.Entities.Evento>(request);
        var dispositivoId = await _repoRead.GetByDispositivoId(request.DispositivoId);
        if (dispositivoId is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Dispositivo_Not_Found);

        }
           await _repo.Add(evento);

        await _unityOfWork.Commit();
        return _mapper.Map<ResponseEvento>(evento);
    }

    private static void Validate(RequestEvento request)
    {
        var validator = new EventoValidator();

        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    

}
}