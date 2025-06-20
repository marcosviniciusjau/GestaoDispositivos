namespace GestaoDispositivos.App.Validations.Dispositivos.Delete;
public interface IDeleteEventoValidation
{
    Task Execute(Guid id);
}
