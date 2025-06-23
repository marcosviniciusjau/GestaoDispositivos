using GestaoDispositivos.Domain.Entities.Enums;

namespace GestaoDispositivos.Communication.Requests;

public class RequestUpdateEvento
{
    public Tipos? Tipo { get; set; }
    public DateTime? DataHora { get; set; }

    public Guid? DispositivoId { get; set; }
 }
