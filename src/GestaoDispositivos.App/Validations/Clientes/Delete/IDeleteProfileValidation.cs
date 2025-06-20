namespace GestaoDispositivos.App.Validations.Clientes.Delete;
public interface IDeleteDispositivoValidation
{
    Task Execute(Guid id);
}
