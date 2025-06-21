namespace GestaoDispositivos.App.Validations.Dispositivos.Delete;
public interface IDeleteDispositivoValidation
{
    Task Execute(Guid id);
}
