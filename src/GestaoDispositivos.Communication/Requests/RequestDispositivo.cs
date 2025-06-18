using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Communication.Requests;

public class RequestDispositivo
{
    public required string Serial { get; set; }= string.Empty;
    public required string IMEI { get; set; } = string.Empty;
    public DateTime DataAtivacao { get; set; }

    public required Guid ClienteId { get; set; }
    public required Cliente Cliente { get; set; } = default!;
}
