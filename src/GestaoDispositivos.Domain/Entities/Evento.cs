namespace GestaoDispositivos.Domain.Entities;
using GestaoDispositivos.Domain.Entities.Enums;

public class Evento
{
    public Guid Id { get; set; }
    public Tipos Tipo { get; set; }
    public DateTime DataHora { get; set; }

    public Guid DispositivoId { get; set; } = default!;
}
