using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;
namespace GestaoDispositivos.App.Validations.Eventos.Update;
public class UpdateEventoValidation(
    IDispositivoRead dispositivoReadOnly,
    IEventoRead eventoReadOnly,
    IEventoUpdate repos,
    IUnitOfWork unitOfWork
 ) : IUpdateEventoValidation
{
    private readonly IEventoRead _eventoReadOnly = eventoReadOnly;
   
    private readonly IDispositivoRead _dispositivoReadOnly = dispositivoReadOnly;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
     private readonly IEventoUpdate _repos = repos;
    public async Task Execute(Guid id, RequestEvento request)
    {
        Validate(request);

        var evento = await _eventoReadOnly.GetById(id);
        if (evento is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Dispositivo_Not_Found);

        }
        evento.Tipo = request.Tipo;
        var dispositivoId = await _dispositivoReadOnly.VerifyIfExists(request.DispositivoId);

        evento.DispositivoId = request.DispositivoId;
        _repos.Update(evento);

        await _unitOfWork.Commit();
    }


    private void Validate(RequestEvento request)
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