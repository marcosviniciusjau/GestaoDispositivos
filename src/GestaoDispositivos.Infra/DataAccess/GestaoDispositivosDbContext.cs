using GestaoDispositivos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoDispositivos.Infra.DataAccess;

internal class GestaoDispositivosDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Admin> Admin { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
