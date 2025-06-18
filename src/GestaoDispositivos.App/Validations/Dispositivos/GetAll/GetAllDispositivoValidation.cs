using AutoMapper;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Services;
using Microsoft.SqlServer.Management.Smo;

namespace GestaoDispositivos.App.Validations.Dispositivos.GetAll;

public class GetAllDispositivoValidation : IGetAllDispositivoValidation
{
    private readonly IDispositivoRead _repo;
    private readonly IMapper _mapper;
    private readonly IClienteLogado _loggedUser;
    public GetAllDispositivoValidation(
        IDispositivoRead repo,
        IMapper mapper,
        IClienteLogado loggedUser
        )
    {
        _repo = repo;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseDispositivo> Execute()
    {
        var loggedUser = await _loggedUser.Get();
        var result = await _repo.GetAll(loggedUser);

        return _mapper.Map<ResponseDispositivo>(result);
    }
}
