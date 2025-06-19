using AutoMapper;
using FluentValidation;
using GestaoDispositivos.App.Validations.Dispositivo;
using GestaoDispositivos.App.Validations.Dispositivo.Register;
using GestaoDispositivos.App.Validations.Eventos;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Dispositivos.Register;
public class RegisterDispositivoValidation : IRegisterDispositivoValidation
{
    private readonly IDispositivoCreate _repo;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public RegisterDispositivoValidation(
        IDispositivoCreate repo,
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

    public async Task<ResponseDispositivo> Execute(RequestDispositivo request)
    {
        await Validate(request);
        var loggedUser = await _loggedUser.Get();

        var dispositivo = _mapper.Map<Domain.Entities.Dispositivo>(request);
        dispositivo.ClienteId = loggedUser.Id;

        await _repo.Add(dispositivo);

        await _unityOfWork.Commit();
        return _mapper.Map<ResponseDispositivo>(dispositivo);
    }

    private async Task Validate(RequestDispositivo request)
    {
        var validator = new DispositivoValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    }
}