using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GestaoDispositivos.Infra.Services;
internal class ClienteLogado : IClienteLogado
{
    private readonly GestaoDispositivosDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public ClienteLogado(GestaoDispositivosDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<Cliente> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext
            .Clientes
            .AsNoTracking()
            .FirstAsync(cliente => cliente.Id == Guid.Parse(identifier));
    }
}