using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.App.Validations.Dispositivos.Update;
public interface IUpdateDispositivoValidation
{
    public Task Execute(Guid id, RequestDispositivo request);
}
