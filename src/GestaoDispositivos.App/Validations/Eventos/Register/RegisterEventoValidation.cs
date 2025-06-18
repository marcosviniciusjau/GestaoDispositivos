using AutoMapper;
using GestaoDispositivos.App.Validations.Dispositivo.Register;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Eventos.Register;
public class RegisterEventoValidation : IRegisterEventoValidation
{
    private readonly IEventoCreate _repo;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public RegisterEventoValidation(
        IEventoCreate repo,
        IUnitOfWork unityOfWork,
        IMapper mapper,
        IClienteLogado loggedUser
        )
    {
        _repo = repo;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseEvento> Execute(RequestEvento request)
    {
        Validate(request);
        var loggedUser = await _loggedUser.Get();

        var expense = _mapper.Map<Evento>(request);
        await _repo.Add(expense);

        await _unityOfWork.Commit();
        return _mapper.Map<ResponseEvento>(expense);
    }

    private static void Validate(RequestEvento request)
    {
        var validator = new EventoValidator();

        var result = validator.Validate(request);

       
    }
}