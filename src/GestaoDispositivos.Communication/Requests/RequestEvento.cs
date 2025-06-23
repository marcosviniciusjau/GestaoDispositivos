using GestaoDispositivos.Domain.Entities.Enums;

namespace GestaoDispositivos.Communication.Requests;

public class RequestEvento
{
    public required Tipos Tipo { get; set; }
    public required DateTime DataHora { get; set; }

    public required Guid DispositivoId { get; set; }
 }
