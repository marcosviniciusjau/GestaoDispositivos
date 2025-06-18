using GestaoDispositivos.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDispositivos.Infra.Migrations;
public static class DataBaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        using var dbContext = serviceProvider.GetRequiredService<GestaoDispositivosDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
