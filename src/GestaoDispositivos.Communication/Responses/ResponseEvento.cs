using GestaoDispositivos.Domain.Entities.Enums;

namespace GestaoDispositivos.Communication.Responses;

public class ResponseEvento
{
    public required Guid Id { get; set; }
    public required Tipos Tipo { get; set; }
    public required DateTime DataHora { get; set; }

    public required Guid DispositivoId { get; set; }
}
