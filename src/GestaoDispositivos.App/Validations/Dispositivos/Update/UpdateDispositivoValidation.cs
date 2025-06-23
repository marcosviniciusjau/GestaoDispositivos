using AutoMapper;
using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;

namespace GestaoDispositivos.App.Validations.Dispositivos.Update;
public class UpdateDispositivoValidation(
    IDispositivoRead dispositivoReadOnly,
    IDispositivoUpdate repos,
    IClienteLogado loggedUser,
    IUnitOfWork unitOfWork
 ) : IUpdateDispositivoValidation
{
    private readonly IDispositivoRead _dispositivoReadOnly = dispositivoReadOnly;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClienteLogado _loggedUser = loggedUser;
    private readonly IDispositivoUpdate _repos = repos;

    public async Task Execute(Guid id, RequestDispositivo request)
    {
        var loggedUser = await _loggedUser.Get();

        Validate(request);

        var dispositivo = await _dispositivoReadOnly.GetById(loggedUser,id);
        if (dispositivo is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Dispositivo_Not_Found);

        }
        dispositivo.Serial = request.Serial;
        dispositivo.IMEI = request.IMEI;

        _repos.Update(dispositivo);

        await _unitOfWork.Commit();
    }


    private void Validate(RequestDispositivo request)
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