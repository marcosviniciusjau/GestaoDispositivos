using GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoDispositivos.Infra.DataAccess;

internal class GestaoDispositivosDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Admin> Admin { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>()
    .Property(e => e.Tipo)
    .HasConversion(new EnumToStringConverter<Tipos>());

        base.OnModelCreating(modelBuilder);
    }

}
