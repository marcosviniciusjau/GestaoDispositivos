using GestaoDispositivos.Infra.Security;
using GestaoDispositivos.Domain.Repos.Clientes;
using GestaoDispositivos.Domain.Repos.Eventos;
using GestaoDispositivos.Domain.Repos.Dispositivos;
using GestaoDispositivos.Domain.Security;
using GestaoDispositivos.Domain.Services;
using GestaoDispositivos.Infra.DataAccess;
using GestaoDispositivos.Infra.DataAccess.Repos;
using GestaoDispositivos.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestaoDispositivos.Domain.Repos;
using GestaoDispositivos.Domain.Repos.Admin;

namespace GestaoDispositivos.Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IClienteLogado, ClienteLogado>(); 
        services.AddScoped<IAdminLogado, AdminLogado>();

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();

        AddRepos(services, config);
        AddDbContext(services, config);
        AddToken(services, config);

    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<ITokenGenerator>(config => new TokenGenerator(expirationMinutes, signingKey!));
    }

    private static void AddRepos(IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAdminCreate, AdminRepo>();
        services.AddScoped<IAdminRead, AdminRepo>();
        services.AddScoped<IAdminDelete, AdminRepo>();


        services.AddScoped<IClienteCreate, ClientesRepo>();
        services.AddScoped<IClienteRead, ClientesRepo>();
        services.AddScoped<IClienteUpdate, ClientesRepo>();
        services.AddScoped<IClienteDelete, ClientesRepo>();

        services.AddScoped<IDispositivoCreate, DispositivosRepo>();
        services.AddScoped<IDispositivoRead, DispositivosRepo>();
        services.AddScoped<IDispositivoUpdate, DispositivosRepo>();
        services.AddScoped<IDispositivoDelete, DispositivosRepo>();

        services.AddScoped<IEventoCreate, EventosRepo>();
        services.AddScoped<IEventoRead, EventosRepo>();
        services.AddScoped<IEventoUpdate, EventosRepo>();
        services.AddScoped<IEventoDelete, EventosRepo>();

    }

    private static void AddDbContext(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Connection");
        services.AddDbContext<GestaoDispositivosDbContext>(config => config.UseSqlServer(connectionString), ServiceLifetime.Scoped);
    }
}
