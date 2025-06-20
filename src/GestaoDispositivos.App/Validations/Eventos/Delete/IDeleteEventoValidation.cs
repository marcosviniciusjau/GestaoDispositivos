namespace GestaoDispositivos.App.Validations.Eventos.Delete;
public interface IDeleteEventoValidation
{
    Task Execute(Guid id);
}
