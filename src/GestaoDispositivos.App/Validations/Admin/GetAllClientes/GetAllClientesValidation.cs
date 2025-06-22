using AutoMapper;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Admin;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Admin.GetAllClientes;

public class GetAllClientesValidation : IGetAllClientesValidation
{
    private readonly IAdminRead _repo;
    private readonly IMapper _mapper;
    private readonly IAdminLogado _loggedUser;
    public GetAllClientesValidation(
        IAdminRead repo,
        IMapper mapper,
        IAdminLogado loggedUser
        )
    {
        _repo = repo;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseClientes> Execute()
    {
        var loggedUser = await _loggedUser.Get();
        var result = await _repo.GetAllClientes(loggedUser);
        return new ResponseClientes
        {
            Clientes = _mapper.Map<List<ResponseCliente>>(result)
        };
    }
}
