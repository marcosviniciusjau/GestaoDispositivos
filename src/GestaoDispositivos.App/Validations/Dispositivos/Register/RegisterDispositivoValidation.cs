using AutoMapper;
using FluentValidation.Results;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;
using GestaoDispositivos.Infra.Migrations;

namespace GestaoDispositivos.App.Validations.Dispositivos.Register;
public class RegisterDispositivoValidation : IRegisterDispositivoValidation
{
    private readonly IDispositivoCreate _repo;
    private readonly IDispositivoRead _dispositivoReadOnly;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    private readonly IAdminLogado _loggedUserAdmin;
    public RegisterDispositivoValidation(
        IDispositivoCreate repo,
        IDispositivoRead dispositivoReadOnly,
        IUnitOfWork unityOfWork,
        IMapper mapper,
        IClienteLogado loggedUser,
        IAdminLogado loggedUserAdmin
        )
    {
        _repo = repo;
        _dispositivoReadOnly = dispositivoReadOnly;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
        _loggedUserAdmin = loggedUserAdmin;
    }

    public async Task<ResponseDispositivo> Execute(RequestDispositivo request)
    {
        await Validate(request);
        var loggedUser= await _loggedUser.Get();
        var dispositivo = _mapper.Map<Dispositivo>(request);
        dispositivo.ClienteId = loggedUser.Id;
        dispositivo.DataAtivacao = DateTime.Now;
        await _repo.Add(dispositivo);

        await _unityOfWork.Commit();
        return _mapper.Map<ResponseDispositivo>(dispositivo);
    }

    private async Task Validate(RequestDispositivo request)
    {
        var validator = new DispositivoValidator();

        var result = validator.Validate(request);
        var exists = await _dispositivoReadOnly.Exists(request.Serial);
        if (exists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.Dispositivo_Exists));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidation(errorMessages);
        }
    }
}