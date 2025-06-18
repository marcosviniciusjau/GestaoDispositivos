using AutoMapper;
using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Domain.Services;

namespace GestaoDispositivos.App.Validations.Users.GetProfile;
public class GetProfileValidation : IGetProfileValidation
{
    private readonly IClienteLogado _loggedUser;
    private readonly IMapper _mapper;
    public GetProfileValidation(IClienteLogado loggedUser, IMapper mapper)
    {
        _loggedUser = loggedUser;
        _mapper = mapper;
    }

    public async Task<ResponseClienteProfile> Execute()
    {
        var user = await _loggedUser.Get();
        return _mapper.Map<ResponseClienteProfile>(user);
    }
}
