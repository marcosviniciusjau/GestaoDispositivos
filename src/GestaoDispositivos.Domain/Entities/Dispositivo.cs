using System;

namespace GestaoDispositivos.Domain.Entities;
public class Dispositivo
{  
    public Guid Id { get; set; } = default!;
    public string Serial { get; set; } = default!;
    public string IMEI { get; set; } = default!;
    public Guid ClienteId { get; set; } = default!; 
    public Cliente Cliente { get; set; } = default!;

    public DateTime DataAtivacao = default!;
}