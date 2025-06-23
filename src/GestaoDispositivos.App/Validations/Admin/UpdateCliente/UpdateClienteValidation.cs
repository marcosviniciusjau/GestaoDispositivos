using GestaoDispositivos.Communication.Requests;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Exception.ExceptionBase;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Exception;
namespace GestaoDispositivos.App.Validations.Admin.UpdateCliente;
public class UpdateClienteValidation(
    IClienteUpdate repos,
    IUnitOfWork unitOfWork
 ) : IUpdateClienteValidation
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClienteUpdate _repos = repos;
    public async Task Execute(Guid clienteId, RequestUpdateCliente request)
    {
        var cliente = await _repos.GetById(clienteId);
        if(cliente is null) throw new NotFoundException(ResourceErrorMessages.Cliente_Not_Found);
        cliente.Status = request.Status;
   
        _repos.Update(cliente);

        await _unitOfWork.Commit();
    }

}