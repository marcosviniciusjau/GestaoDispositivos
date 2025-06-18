namespace GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;

public class Evento
{
    public long Id { get; set; }
    public Tipos Tipo { get; set; }
    public DateTime DataHora { get; set; }

    public Guid DispositivoId { get; set; }
    public Dispositivo Dispositivo { get; set; } = default!;
}
