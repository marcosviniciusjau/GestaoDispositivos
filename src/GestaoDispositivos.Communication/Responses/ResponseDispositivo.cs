using GestaoDispositivos.Domain.Entities;

namespace GestaoDispositivos.Communication.Responses;

public class ResponseDispositivo
{
    public required Guid Id { get; set; }
    public required string Serial { get; set; } = string.Empty;
    public required string IMEI { get; set; } = string.Empty;
    public required DateTime DataAtivacao { get; set; }

}
